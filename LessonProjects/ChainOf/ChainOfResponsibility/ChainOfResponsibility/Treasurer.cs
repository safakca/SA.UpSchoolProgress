using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility;
public class Treasurer : Employee
{
    public override void ProcessRequest(WithdrawViewModel req)
    {
        if (req.Amount <= 40000)
        {
            using (var context = new Context())
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi gerçekleştirildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
        }
        else if (NextApprover != null)
        {
            using (var context = new Context())
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdür Yardımcısına gönderildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
