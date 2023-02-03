using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility;
public class Manager : Employee
{
    public override void ProcessRequest(WithdrawViewModel req)
    {
        if (req.Amount <= 1500000)
        {
            using (var context = new Context())
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Şube Müdürü-Hakan Kayalı";
                bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdürü tarafından gerçekleştirildi.";
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
                bankProcess.EmployeeName = "Şube Müdürü - Hakan Kayalı";
                bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Bölge Müdürüne gönderildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
