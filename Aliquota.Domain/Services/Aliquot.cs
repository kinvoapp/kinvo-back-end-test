using Aliquota.Domain.Dao;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Services
{
    public static class Aliquot
    {
        public static AliquotContext context;
        

        public static Investment Apply(decimal value, DateTime? application=null)
        {
            if (value == 0)
            {
                throw new BusinessException("Zero Investment");
            } else if (value < 0)
            {
                throw new BusinessException("Negative Investment");

            }
                                                     
            if (application == null)
            {
                application = DateTime.Now.Date;
            }
            

            var investment = new Investment() {
                Value = value,
                Application = (DateTime)application
            };

            var dao = new InvestmentDao(context.Investments);
            dao.Insert(investment);
            context.SaveChanges();
            return investment;

        }

        public static void AddProfit(int id, decimal value)
        {
            if (value == 0)
            {
                throw new BusinessException("Zero Profit!");
            }
            else if (value < 0)
            {
                throw new BusinessException("Negative Profit!");
            }

            if (id == 0)
            {
                throw new BusinessException("Not Found");
            }

            var investment = context.Investments.Find(new object[] { id });
            if (investment == null)
            {
                throw new BusinessException("Not Found");
            }

            investment.Profit += value;

            context.SaveChanges();
        }
        public static decimal Rescue(int id)
        {
            if (id==0)
            {
                throw new BusinessException("Not Found");
            }

            var investment = context.Investments.Find(new object[] { id });
            if (investment == null)
            {
                throw new BusinessException("Not Found");
            }


            var span = investment.Application - DateTime.Now;
            if (span.Days >0)
            {
                throw new BusinessException("Invalid Operation! The date of rescue is less than date of application.");
            }

            if (Math.Abs(span.Days) < 365)
            {
                var discount = investment.Profit * 0.225M;
                var rescue = investment.Value + (investment.Profit - discount);
                context.Investments.Remove(investment);
                context.SaveChanges();
                return rescue;
            }

            if (Math.Abs(span.Days) >= 365 && Math.Abs(span.Days) < (365 *2))
            {
                var discount = investment.Profit * 0.185M;
                var rescue = investment.Value + (investment.Profit - discount);
                context.Investments.Remove(investment);
                context.SaveChanges();
                return rescue;
            }

            if (Math.Abs(span.Days) >= (365 * 2))
            {
                var discount = investment.Profit * 0.15M;
                var rescue = investment.Value + (investment.Profit - discount);
                context.Investments.Remove(investment);
                context.SaveChanges();
                return rescue;
            }

            throw new BusinessException("Unkown Error");

        }
    }
}
