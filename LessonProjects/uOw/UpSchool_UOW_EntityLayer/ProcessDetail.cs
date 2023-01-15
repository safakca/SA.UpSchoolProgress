using System;

namespace UpSchool_UOW_EntityLayer;
public class ProcessDetail
{
    public int ProcessDetailID { get; set; }
    public string ReceiverName { get; set; }
    public string SenderName { get; set; }
    public decimal Amount { get; set; }
    public DateTime ProcessDate { get; set; }
}
