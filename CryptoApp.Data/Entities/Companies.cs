using CryptoApp.Data.EntityAbstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Data.Entities
{
    public class Companies : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
