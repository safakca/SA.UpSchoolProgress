﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_SignalR_Api2.Models;

namespace UpSchool_SignalR_Api2.Hubs;
public class ElectricService
{
    private readonly Context _context;
    private readonly IHubContext<ElectricHub> _hubContext;

    public ElectricService(Context context, IHubContext<ElectricHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }
    public IQueryable<Electric> GetList()
    {
        return _context.Electrics.AsQueryable();
    }
    public async Task SaveElectric(Electric electric)
    {
        await _context.Electrics.AddAsync(electric);
        await _context.SaveChangesAsync();
        await _hubContext.Clients.All.SendAsync("ReceiveElectricList", "data");
    }

    public List<ElectricChart> GetElectricChartList()
    {
        List<ElectricChart> electricCharts = new List<ElectricChart>();
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "Select tarih,[1],[2],[3],[4],[5] from (select[City],[Count],cast([ElectricDate] as date) as tarih From Electrics) as electricT pivot (Sum(count) for city in([1],[2],[3],[4],[5])) as ptable order by tarih asc";
            command.CommandType = System.Data.CommandType.Text;
            _context.Database.OpenConnection();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ElectricChart electricChart = new ElectricChart();
                    electricChart.ElectricDate = reader.GetDateTime(0).ToShortDateString();
                    Enumerable.Range(1, 5).ToList().ForEach(x =>
                    {
                        if (System.DBNull.Value.Equals(reader[x]))
                        {
                            electricChart.Counts.Add(0);
                        }
                        else
                        {
                            electricChart.Counts.Add(reader.GetInt32(x));
                        }
                    });
                    electricCharts.Add(electricChart);
                }
            }
            _context.Database.CloseConnection();
            return electricCharts;
        }
    }
}
