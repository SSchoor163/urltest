using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using testurl3.Models;

namespace testurl3.Services
{
    public class GtMetricsServices : IGtMetricsServices
    {
        private readonly IGtMetricsRepo _gtMetricsRepo;
        private readonly ICompanyServices _companyServices;
        public GtMetricsServices(IGtMetricsRepo gtMetricsRepo, ICompanyServices companyServices)
        {
            _gtMetricsRepo = gtMetricsRepo;
            _companyServices = companyServices;
        }

        public GtMetrics Get(int id)
        {
            var gtmetric = _gtMetricsRepo.Get(id);
            return gtmetric;
        }

        public IEnumerable<GtMetrics> GetAll()
        {
            var gtMetrics = _gtMetricsRepo.GetAll();
            return gtMetrics;
        }
        public GtMetricsPostResponce PostTest(string url)
        {
            var client = new RestClient("https://gtmetrix.com/api/0.1/test");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic c3NjaG9vckBzbW9vdGhmdXNpb24uY29tOjA1YzYyNmE4OTEyMWQwZGM2MzY1Y2E4OTAwMDE0N2Zk");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("url", url);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                string responseStream = response.Content;
                int index = responseStream.IndexOf(':');
                string temp = responseStream.Remove(0, index + 1);
                index = temp.IndexOf(',');
                string creditsLeft = temp.Substring(0, index);
                index = temp.IndexOf(':');
                temp = temp.Remove(0, index + 2);
                index = temp.IndexOf('\"');
                string testId = temp.Substring(0, index);
                index = temp.IndexOf(':');
                temp = temp.Remove(0, index + 2);
                index = temp.IndexOf('\"');
                string pollStateUrl = temp.Substring(0, index);
                GtMetricsPostResponce deserializedResponse = new GtMetricsPostResponce
                {
                    credits_left = int.Parse(creditsLeft),
                    test_id = testId,
                    poll_state_url = pollStateUrl
                };
                return deserializedResponse;
            }
            return null;
        }

        public async Task<GtMetrics> GetTest(string url, int companyId)
        {
            var client = new RestClient(url);
            client.Timeout = 5000;
            client.UseSystemTextJson();
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic c3NjaG9vckBzbW9vdGhmdXNpb24uY29tOjA1YzYyNmE4OTEyMWQwZGM2MzY1Y2E4OTAwMDE0N2Zk");
            request.AlwaysMultipartFormData = true;

            var response = await client.UseJson().ExecuteAsync<GtMetricsDomainModel>(request);

            while (response.Data.state != "completed")
            {
                response = await client.UseJson().ExecuteAsync<GtMetricsDomainModel>(request);
                if (!response.IsSuccessful)
                {
                    throw response.ErrorException;
                }
            }
            GtMetrics FinalResult = new GtMetrics()
            {
                Error = response.Data.error,
                ReportUrl = response.Data.results.report_url,
                PageSpeedScore = response.Data.results.pagespeed_score,
                YSlowScore = response.Data.results.yslow_score,
                HtmlBytes = response.Data.results.html_bytes,
                HtmlLoadTime = response.Data.results.html_load_time,
                PageBytes = response.Data.results.page_bytes,
                PageLoadTime = response.Data.results.page_load_time,
                PageElements = response.Data.results.page_elements,
                FullyLoadedTime = response.Data.results.fully_loaded_time,
                BackendDuration = response.Data.results.backend_duration,
                CompanyId = companyId,
                ConnectionDuration = response.Data.results.connect_duration,
                DomContentLoadedDuration = response.Data.results.dom_content_loaded_duration,
                DomContentLoadedTime = response.Data.results.dom_content_loaded_time,
                DomInteractiveTime = response.Data.results.dom_interactive_time,
                FilmStrip = response.Data.resources.filmstrip,
                FirstContentfulPaintTime = response.Data.results.first_contentful_paint_time,
                FirstPaintTime = response.Data.results.first_paint_time,
                HARFile = response.Data.resources.har,
                OnloadTime = response.Data.results.onload_time,
                PageSpeed = response.Data.resources.pagespeed,
                PageSpeedFiles = response.Data.resources.pagespeed_files,
                RedirectDuration = response.Data.results.redirect_duration,
                ReportPdf = response.Data.resources.report_pdf,
                ReportPdfFull = response.Data.resources.report_pdf_full,
                RumSpeedIndex = response.Data.results.rum_speed_index,
                Screenshot = response.Data.resources.screenshot,
                Video = response.Data.resources.video,
                YSlow = response.Data.resources.yslow
            };
            return FinalResult;
        }
        public async Task<GtMetrics> Test(string url, int companyId)
        {
           
                GtMetricsPostResponce Post = PostTest(url);
                if (Post == null) throw new Exception("Error posting a url to External api");

                GtMetrics Get = await GetTest(Post.poll_state_url, companyId);
                if (Get == null) throw new Exception("Error getting gtmetric from external api");

                return Get;
        }

        public GtMetrics Add(GtMetrics gtMetric)
        {
            Company company = _companyServices.Get(gtMetric.CompanyId);
            if (company == null)
            {
                throw new Exception("Error getting company targeted by new metric. Are you sure the comapny Id you posted exists?");
            }
            int CompanyGtMetricId = company.GtMetricsId;
            GtMetrics metric;
            if (CompanyGtMetricId == 0)
            {
                metric = _gtMetricsRepo.Add(gtMetric);
                if (metric == null) throw new Exception("Error new adding metric");
            }
            else
            {
                metric = _gtMetricsRepo.Update(gtMetric);
                if (metric == null) throw new Exception("Error new updating exiting metric");
            }

            
            
            
            
            return metric;
        }
        public void Remove(int id)
        {
            _gtMetricsRepo.Remove(id);
        }

    }
}
