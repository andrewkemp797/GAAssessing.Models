using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Helpers
{
    public static class SerializationHelper
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        /// <summary>
        /// Serializes and deserializes the model. This workaround may be necessary to resolve reference loops in database entities.
        /// </summary>
        /// <typeparam name="T">The type of the model to process.</typeparam>
        /// <param name="entity">The model.</param>
        public static T ProcessEntity<T>(T entity)
            => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(entity, _settings));
    }
}
