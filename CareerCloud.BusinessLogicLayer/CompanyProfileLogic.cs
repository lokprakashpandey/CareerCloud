using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic:BaseLogic<CompanyProfilePoco>
    {
        //CompanyProfileRepository _repo = new CompanyProfileRepository();
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository):base(repository)
        {

        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            //_repo.Update(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            if(pocos != null)
            {
                foreach (CompanyProfilePoco poco in pocos)
                {
                    if (!string.IsNullOrEmpty(poco.CompanyWebsite))
                    {
                        string substr1 = poco.CompanyWebsite.Substring(poco.CompanyWebsite.Length - 3);
                        string substr2 = poco.CompanyWebsite.Substring(poco.CompanyWebsite.Length - 4);
                        if (!(substr1.CompareTo(".ca") == 0 || substr2.CompareTo(".biz") == 0
                            || substr2.CompareTo(".com") == 0))
                        {
                            exceptions.Add(new ValidationException(600,
                                $"Valid websites must end with the following extensions – .ca, .com, .biz - {poco.Id}"));
                        }
                    }

                    if (string.IsNullOrEmpty(poco.ContactPhone))
                    {
                        exceptions.Add(new ValidationException(601,
                            $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                    }
                    else
                    {
                        string[] phoneComponents = poco.ContactPhone.Split('-');
                        if (phoneComponents.Length < 3)
                        {
                            exceptions.Add(new ValidationException(601,
                            $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                        }
                        else
                        {
                            if (phoneComponents[0].Length < 3)
                            {
                                exceptions.Add(new ValidationException(601,
                            $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                            }
                            else if (phoneComponents[1].Length < 3)
                            {
                                exceptions.Add(new ValidationException(601,
                            $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                            }
                            else if (phoneComponents[2].Length < 4)
                            {
                                exceptions.Add(new ValidationException(601,
                            $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                            }
                        }
                    }
                }

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                } 
            }
            
        }
    }
}
