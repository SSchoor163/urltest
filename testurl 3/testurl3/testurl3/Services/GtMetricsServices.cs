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
        private readonly IHttpClientFactory _clientFactory;
        public GtMetricsServices(IGtMetricsRepo gtMetricsRepo, IHttpClientFactory clientFactory)
        {
            _gtMetricsRepo = gtMetricsRepo;
            _clientFactory = clientFactory;
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

        public async Task<GtMetrics> PostTest(string url, int companyId)
        {
            var client = new RestClient("https://gtmetrix.com/api/0.1/test");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic c3NjaG9vckBzbW9vdGhmdXNpb24uY29tOjA1YzYyNmE4OTEyMWQwZGM2MzY1Y2E4OTAwMDE0N2Zk");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("url", "kubotausa.com");
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

                var getClient = new RestClient(deserializedResponse.poll_state_url);
                getClient.Timeout = 5000;
                getClient.UseSystemTextJson();
                var getRequest = new RestRequest(Method.GET);
                getRequest.AddHeader("Authorization", "Basic c3NjaG9vckBzbW9vdGhmdXNpb24uY29tOjA1YzYyNmE4OTEyMWQwZGM2MzY1Y2E4OTAwMDE0N2Zk");
                getRequest.AlwaysMultipartFormData = true;

                var getResponse = await getClient.UseJson().ExecuteAsync<GtMetricsDomainModel>(getRequest);

                while (getResponse.Data.state != "completed")
                {
                    getResponse = await getClient.UseJson().ExecuteAsync<GtMetricsDomainModel>(getRequest);
                    if (!getResponse.IsSuccessful)
                    {
                        throw getResponse.ErrorException;
                    }
                }
                GtMetrics FinalResult = new GtMetrics()
                {
                    Error = getResponse.Data.error,
                    ReportUrl = getResponse.Data.results.report_url,
                    PageSpeedScore = getResponse.Data.results.pagespeed_score,
                    YSlowScore = getResponse.Data.results.yslow_score,
                    HtmlBytes = getResponse.Data.results.html_bytes,
                    HtmlLoadTime = getResponse.Data.results.html_load_time,
                    PageBytes = getResponse.Data.results.page_bytes,
                    PageLoadTime = getResponse.Data.results.page_load_time,
                    PageElements = getResponse.Data.results.page_elements,
                    FullyLoadedTime = getResponse.Data.results.fully_loaded_time,
                    BackendDuration = getResponse.Data.results.backend_duration,
                    CompanyId = companyId,
                    ConnectionDuration = getResponse.Data.results.connect_duration,
                    DomContentLoadedDuration = getResponse.Data.results.dom_content_loaded_duration,
                    DomContentLoadedTime = getResponse.Data.results.dom_content_loaded_time,
                    DomInteractiveTime = getResponse.Data.results.dom_interactive_time,
                    FilmStrip = getResponse.Data.resources.filmstrip,
                    FirstContentfulPaintTime = getResponse.Data.results.first_contentful_paint_time,
                    FirstPaintTime = getResponse.Data.results.first_paint_time,
                    HARFile = getResponse.Data.resources.har,
                    OnloadTime = getResponse.Data.results.onload_time,
                    PageSpeed = getResponse.Data.resources.pagespeed,
                    PageSpeedFiles = getResponse.Data.resources.pagespeed_files,
                    RedirectDuration = getResponse.Data.results.redirect_duration,
                    ReportPdf = getResponse.Data.resources.report_pdf,
                    ReportPdfFull = getResponse.Data.resources.report_pdf_full,
                    RumSpeedIndex = getResponse.Data.results.rum_speed_index,
                    Screenshot = getResponse.Data.resources.screenshot,
                    Video = getResponse.Data.resources.video,
                    YSlow = getResponse.Data.resources.yslow
                };
                GtMetrics getMetric = _gtMetricsRepo.Get(companyId);
                if(getMetric != null)
                {
                    return _gtMetricsRepo.Update(FinalResult);
                }
                    
                    return _gtMetricsRepo.Add(FinalResult);
            }
            return null;
        }

        public void Remove(int id)
        {
            _gtMetricsRepo.Remove(id);
        }

        public GtMetrics Update(GtMetrics gtMetric)
        {
            var GtMetric = _gtMetricsRepo.Update(gtMetric);
            return GtMetric;
        }
    }
}
