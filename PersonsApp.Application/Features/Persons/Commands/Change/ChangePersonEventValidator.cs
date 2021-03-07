using FluentValidation;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Commands.Change
{
    public class ChangePersonEventValidator : AbstractValidator<ChangePersonCommand>
    {
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Person> _personRepository;
        public ChangePersonEventValidator(IRepository<Gender> genderRepository, IRepository<City> cityRepository, IRepository<Person> personRepository)
        {
            _genderRepository = genderRepository;
            _cityRepository = cityRepository;
            _personRepository = personRepository;

            RuleFor(e => e.Id)
                .MustAsync(PersonExists).WithMessage("{PropertyName} არ არსებობს");

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

        }

        private async Task<bool> PersonExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _personRepository.GetOneByIdAsync(id);
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
