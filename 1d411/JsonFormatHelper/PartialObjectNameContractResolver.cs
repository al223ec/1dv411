using _1dv411.Domain.DbEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1d411.JsonFormatHelper
{
    //Denna klass är tänkt att lägga till ett värde för vilken typ av partial som ska skrivas ut, får inte till detta idag
    public class PartialObjectNameContractResolver : CamelCasePropertyNamesContractResolver
    {
        public PartialObjectNameContractResolver()
        { }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
       {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            // only serializer properties that start with the specified character

            //foreach (var property in properties)
            //{
            //    if (property.DeclaringType == typeof(Diagram))
            //    {
            //          new JsonProperty{
            //           PropertyName = "type",
            //           V
            //        }
            //    }
            //}

            return properties;
        }

        //protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        //{
        //    JsonProperty property = base.CreateProperty(member, memberSerialization);

        //    if (property.DeclaringType == typeof(Diagram))
        //    {
        //        property.ShouldSerialize =
        //            instance =>
        //            {
        //                Employee e = (Employee)instance;
        //                return e.Manager != e;
        //            };
        //    }

        //    return property;

        //}
    }
}