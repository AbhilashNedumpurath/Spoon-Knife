using SampleApp.Order;
using SampleApp.OrderItems;
using SampleApp.Rules;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book.Rules = new List<IRule> {  new GenerateDuplicatePackingSlip(), new CommitionPayment() };
            PhysicalItem.Rules = new List<IRule> { new GeneratePackingSlip(), new CommitionPayment() };
            MembershipActivate.Rules = new List<IRule> { new ActivateMembership(), new EmailMembershipDetail() };
            MembershipUpgrade.Rules = new List<IRule> { new UpgradeMembership(), new EmailMembershipDetail() };

            Customer customer = new Customer();
            customer.Order(new Book());
            customer.Order(new MembershipActivate());
            customer.DoPayment();

            Console.ReadLine();
        }
    }
}
