﻿using BirthdayTekken.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BirthdayTekken.Models.ViewModel
{
    public class MatchMaker : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Participant_MatchMaker> Participant_MatchMakers { get; set; }


    }
}