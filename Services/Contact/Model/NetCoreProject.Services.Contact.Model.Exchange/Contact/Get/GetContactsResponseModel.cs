﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.Get
{
    public class GetContactsResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + "-" + Surname;
        public int Age { get; set; }
    }
}
