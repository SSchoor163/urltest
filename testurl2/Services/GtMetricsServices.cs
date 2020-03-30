
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using testurl2.Models;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;


namespace testurl2.Services
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

        public async Task<GtMetrics> PostTest(string url, int companyId)
        {
            GtMetrics result;

            var request = new HttpRequestMessage(HttpMethod.Get,
            url);
            request.Headers.Add("Authorization", "Bearer " + "c3NjaG9vckBzbW9vdGhmdXNpb24uY29tOjA1YzYyNmE4OTEyMWQwZGM2MzY1Y2E4OTAwMDE0N2Zk");
            request.Headers.Add("Content-Type", "multipart/form-data;");
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Connection", "keep-alive");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var deserializedResponse = JsonConvert.DeserializeObject<GtMetricsDomainModel>(responseStream);
                //Note to self need to creat an extension method or something to correctly conver this
                result = new GtMetrics()
                {
                    Error = deserializedResponse.error,
                    ReportUrl = deserializedResponse.results.report_url,
                    PageSpeedScore = deserializedResponse.results.pagespeed_score,
                    YSlowScore = deserializedResponse.results.yslow_score,
                    HtmlBytes = deserializedResponse.results.html_bytes,
                    HtmlLoadTime = deserializedResponse.results.html_load_time,
                    PageBytes = deserializedResponse.results.page_bytes,
                    PageLoadTime = deserializedResponse.results.page_load_time,
                    PageElements = deserializedResponse.results.page_elements,
                    FullyLoadedTime = deserializedResponse.results.fully_loaded_time,
                    BackendDuration = deserializedResponse.results.backend_duration,
                    CompanyId = companyId,
                    ConnectionDuration = deserializedResponse.results.connect_duration,
                    DomContentLoadedDuration = deserializedResponse.results.dom_content_loaded_duration,
                    DomContentLoadedTime = deserializedResponse.results.dom_content_loaded_time,
                    DomInteractiveTime = deserializedResponse.results.dom_interactive_time,
                    FilmStrip = deserializedResponse.resources.filmstrip,
                    FirstContentfulPaintTime = deserializedResponse.results.first_contentful_paint_time,
                    FirstPaintTime = deserializedResponse.results.first_paint_time,
                    HARFile = deserializedResponse.resources.har,
                    OnloadTime = deserializedResponse.results.onload_time,
                    PageSpeed = deserializedResponse.resources.pagespeed,
                    PageSpeedFiles = deserializedResponse.resources.pagespeed_files,
                    RedirectDuration = deserializedResponse.results.redirect_duration,
                    ReportPdf = deserializedResponse.resources.report_pdf,
                    ReportPdfFull = deserializedResponse.resources.report_pdf_full,
                    RumSpeedIndex = deserializedResponse.results.rum_speed_index,
                    Screenshot = deserializedResponse.resources.screenshot,
                    Video = deserializedResponse.resources.video,
                    YSlow = deserializedResponse.resources.yslow
                };
                if (_gtMetricsRepo.Get(companyId) != null)
                {
                    _gtMetricsRepo.Update(result);
                }
                else _gtMetricsRepo.Add(result);
                return result;
            }
            else return null;
        }
    }
}
