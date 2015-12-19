﻿namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.KinematicViscosity"/>.
    /// </summary>
    [Serializable]
    public class KinematicViscosityJsonConverter : JsonConverter
    {
        public static readonly KinematicViscosityJsonConverter Default = new KinematicViscosityJsonConverter(KinematicViscosityUnit.SquareMetresPerSecond);
        public static readonly KinematicViscosityJsonConverter SquareMetresPerSecond = new KinematicViscosityJsonConverter(KinematicViscosityUnit.SquareMetresPerSecond);

        private readonly KinematicViscosityUnit unit;

        private KinematicViscosityJsonConverter(KinematicViscosityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var kinematicViscosity = (KinematicViscosity)value;
            serializer.Serialize(writer, kinematicViscosity.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KinematicViscosity);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return KinematicViscosity.Parse(stringValue, serializer.Culture);
        }
    }
}