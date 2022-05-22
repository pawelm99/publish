using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class Computers
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Display(Name="Computer name")]
        public string Name { get; set; }

        [Display(Name ="Creation year")]
        public int Year { get; set; }

        public string ImageId { get; set; }

        public bool HasImage()=> !string.IsNullOrEmpty(ImageId);    

    }
}
