using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Konvolucio.MBOM220411.Data;

namespace Data
{

        [TestFixture]
        public class MaterialsUnitTest
        {
            [Test]
            public void MaterialRead()
            {

                var i = Db.Instance.Materials.DataSource().Rows[0];

                Assert.IsNotNull(i);

            }
        }


}
