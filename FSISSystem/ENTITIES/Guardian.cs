﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace FSISSystem.ENTITIES
{
    [Table("Guardian")]
    public class Guardian
    {
        public int GuardianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
