using AutoMapper;
using DataAccess.IRepository;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        private readonly IStatisticalRepository _statisticalRepository;


        public StatisticalController(IStatisticalRepository statisticalRepository)
        {
            _statisticalRepository = statisticalRepository;
        }

        [HttpGet]
        public IActionResult GetStatistical(int month)
        {
            var statistical = _statisticalRepository.GetStatistical(month);

            //DataTable ChartData = new DataTable();
            //ChartData.Columns.Add("RoomName", typeof(System.String));
            //ChartData.Columns.Add("Total", typeof(System.Decimal));
            //ChartData.Columns.Add("CountBooking", typeof(System.Decimal));
            //foreach (var item in statistical)
            //{
            //    ChartData.Rows.Add(item.RoomName, item.Total, item.CountBooking);

            //}

            //StaticSource source = new StaticSource(ChartData);
            //DataModel model = new DataModel();
            //model.DataSources.Add(source);
            //Charts.ColumnChart column = new Charts.ColumnChart("first_chart");
            //column.Width.Pixel(1000);
            //column.Height.Pixel(400);
            //column.Data.Source = model;
            //column.Caption.Text = "Test do thi";
            //column.Legend.Show = false;
            //column.XAxis.Text = "RoomName";
            //column.YAxis.Text = "Total";
            //column.YAxis.Text = "CountBooking";
            //column.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            //var ChartJson = column.Render();
            //return Ok(ChartJson);

            var data = statistical.Select(x => new
            {
                label = x.RoomName,
                value = x.Total,
                profit = x.CountBooking
            }).ToArray();
            return Ok(data);
        }
    }
}
