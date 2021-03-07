using FluentValidation;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Commands.Create
{
    public class CreatePersonEventValidator: AbstractValidator<CreatePersonCommand>
    {
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<PhoneType> _phoneTypeRepository;

        public CreatePersonEventValidator(IRepository<Gender> genderRepository, IRepository<City> cityRepository, IRepository<Person> personRepository, IRepository<PhoneType> phoneTypeRepository)
        {
            _genderRepository = genderRepository;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
            _phoneTypeRepository = phoneTypeRepository;

            RuleFor(e => e.FirstName)
                .MinimumLength(2).WithMessage("{PropertyName} არ შეიძლება იყოს 2 სიმბოლოზე ნაკლები")
                .MaximumLength(50).WithMessage("{PropertyName} არ შეიძლება იყოს 50 სიმბოლოზე მეტი")
                .Matches("^([a-zA-Z]*|[ა-ჰ]*)$").WithMessage("{PropertyName} შეიძლება შეიცავდეს ქართულ ან ლათინურ ასოებს");

            RuleFor(e => e.LastName)
                .MinimumLength(2).WithMessage("{PropertyName} არ შეიძლება იყოს 2 სიმბოლოზე ნაკლები")
                .MaximumLength(50).WithMessage("{PropertyName} არ შეიძლება იყოს 50 სიმბოლოზე მეტი")
                .Matches("^([a-zA-Z]*|[ა-ჰ]*)$").WithMessage("{PropertyName} შეიძლება შეიცავდეს ქართულ ან ლათინურ ასოებს");

            RuleFor(e => e.PersonalN)
                .Length(11).WithMessage("{PropertyName} უნდა იყოს 11 სიგრძის")
                .Matches("^\\d*$").WithMessage("{PropertyName} უნდა შეიცავდეს მხოლოდ ციფრებს");

            RuleFor(e => e.BirthDate)
                .ExclusiveBetween(DateTime.MinValue, DateTime.Now.AddYears(-18)).WithMessage("პიროვნება არ შეიძლება იყოს არასრულწლოვანი");

            RuleFor(e => e.GenderId)
                .MustAsync(GenderExists).WithMessage("{PropertyName} არ არსებობს");

            RuleFor(e => e.CityId)
                .MustAsync(CityExists).WithMessage("{PropertyName} არ არსებობს");

            RuleForEach(x => x.PhoneNumbers).ChildRules(orders =>
            {
                orders.RuleFor(x => x.Number)
                    .MinimumLength(4).WithMessage("{PropertyName} არ შეიძლება იყოს 4 სიმბოლოზე ნაკლები")
                    .MaximumLength(50).WithMessage("{PropertyName} არ შეიძლება იყოს 50 სიმბოლოზე მეტი")
                    .Matches("^\\d*$").WithMessage("{PropertyName} უნდა შეიცავდეს მხოლოდ ციფრებს");

                orders.RuleFor(x => x.PhoneTypeId)
                    .MustAsync(PhoneTypeExists).WithMessage("{PropertyName} არ არსებობს");

            });
            _phoneTypeRepository = phoneTypeRepository;
        }

        private async Task<bool> PhoneTypeExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _phoneTypeRepository.GetOneByIdAsync(id);
            if (result is null)
                return false;

            return true;
        }
        private async Task<bool> CityExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _cityRepository.GetOneByIdAsync(id);
            if (result is null)
                return false;

            return true;
        }
        private async Task<bool> GenderExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _genderRepository.GetOneByIdAsync(id);
            if (result is null)
                return false;

            return true;
        }

    }
}
