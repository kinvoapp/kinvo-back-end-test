using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.DataContext;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Test
{
    [TestClass]
    public class ApplicationITTest
    {
        [TestMethod]
        public async Task RescueApplication()
        {
            //ApplicationITRepository _applicationITRepository = new ApplicationITRepository(new ApplicationITDataContext());

            //ApplicationIT application = new ApplicationIT();


            //application.SetValue(1421.2F);

            //application.SetTimeAction(12,365);

            //application.SetProfitWithInterest(1.1F);

            //application.SetFullProfit(1.1F);

            //await _applicationITRepository.Include(application);

        }


        [TestMethod]
        public async Task GetAll()
        {
            //ApplicationITRepository _applicationITRepository = new ApplicationITRepository();

            //List<ApplicationIT> application = await _applicationITRepository.GetAll();

            //Assert.IsNotNull(application);
        }
    }
}
