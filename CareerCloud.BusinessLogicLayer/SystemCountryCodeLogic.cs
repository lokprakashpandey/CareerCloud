using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic:SystemCountryCodePoco
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
            _repository = repository;
        }

        protected virtual void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            if (pocos != null)
            {
                foreach (SystemCountryCodePoco poco in pocos)
                {
                    if (string.IsNullOrEmpty(poco.Code))
                    {
                        exceptions.Add(new ValidationException(900,
                            $"Cannot be empty - {poco.Code}"));
                    }

                    if (string.IsNullOrEmpty(poco.Name))
                    {
                        exceptions.Add(new ValidationException(901,
                            $"Cannot be empty - {poco.Code}"));
                    }

                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public virtual SystemCountryCodePoco Get(string code)
        {
            SystemCountryCodePoco poco = _repository.GetSingle(c => c.Code == code);
            return poco;
        }

        public virtual List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public virtual void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }
    }
}
