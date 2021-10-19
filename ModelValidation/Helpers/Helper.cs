using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Helpers
{
    public class Helper
    {
        public void RemoveIds(JObject jObject, string[] props)
        {
            List<JProperty> jProperties = jObject.Properties().ToList();

            for (int i = 0; i < jProperties.Count; i++)
            {
                JProperty jProperty = jProperties[i];
                if (jProperty.Value.Type == JTokenType.Array)
                {
                    RemoveFromArray((JArray)jProperty.Value, props);
                }
                else if (jProperty.Value.Type == JTokenType.Object)
                {
                    RemoveIds((JObject)jProperty.Value, props);
                }
                else if (props.Contains(jProperty.Name.ToLower()))
                {
                    jProperty.Remove();
                }
            }
        }
        private void RemoveFromArray(JArray jArray, string[] props)
        {
            foreach (JObject jObject in jArray)
            {
                RemoveIds(jObject, props);
            }
        }
    }
}
