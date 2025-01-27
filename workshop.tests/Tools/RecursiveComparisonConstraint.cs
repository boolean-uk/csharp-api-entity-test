using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace workshop.tests.Tools
{

    public class RecursiveComparisonConstraint : Constraint
    {
        public object Expected { get; }

        public override string Description => "Compares the properties of two objects recursively";

        public RecursiveComparisonConstraint(object expected)
        {
            Expected = expected;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (actual == null || Expected == null)
            {
                return new ConstraintResult(this, actual, Equals(actual, Expected));
            }

            return new ConstraintResult(this, actual, Compare(actual, Expected));
        }

        public static bool Compare<T>(T obj1, T obj2) where T : class
        {
            if (obj1 == null || obj2 == null)
            {
                return obj1 == obj2;
            }

            if (ReferenceEquals(obj1, obj2)) return true;

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);

                if (value1 != null && value2 != null && property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    if (!Compare(value1, value2))
                    {
                        return false;
                    }
                }
                else
                {
                    if (value1 == null && value2 == null)
                    {
                        continue;
                    }

                    if (value1 == null || value2 == null || !Equals(value1, value2))
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
    }
}
