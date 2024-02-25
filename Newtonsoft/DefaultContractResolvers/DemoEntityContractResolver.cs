using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Dtos;

namespace Newtonsoft.DefaultContractResolvers
{
    public class DemoEntityContractResolver : DefaultContractResolver
    {
        public static JsonSerializerSettings Settings => new() { ContractResolver = new DemoEntityContractResolver() };

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            if (type.GetType().Equals(typeof(DemoEntity)))
            {
                throw new Exception($"This contractor is not valid for {type.GetType()}");
            }

            //var t = type as DemoEntity;

            return
                    base.CreateProperties(type, memberSerialization)
                    .Where(p =>
                    {
                        //p.PropertyName.StartsWith(_startingWithChar.ToString());

                        return true;
                    })
                    .ToList();
        }
    }

    //DemoEntity.Id
    //DemoEntity.Name
    //DemoEntity.Description
    //DemoEntity.Tags
}
