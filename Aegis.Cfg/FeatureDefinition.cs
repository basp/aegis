namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FeatureDefinition : IFeatureDefinition
    {
        private readonly IEnumerable<Field> fields;

        public FeatureDefinition(IEnumerable<Field> fields)
        {
            this.fields = fields;
        }

        public int FieldCount => this.fields.Count();

        public IFieldDefinition GetFieldDefinition(int index)
        {
            return this.fields.ElementAt(index);
        }
    }
}
