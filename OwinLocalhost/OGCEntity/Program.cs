using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddData();
                
            Console.ReadKey();
        }

        static void AddData()
        {
            #region 新增假資料

            using (OGCDbContext db = new OGCDbContext())
            {

                db.thing.Add(new OGCCodeEF.Model.thing()
                {
                    Name = "烤箱",
                    Description = "這個是烤箱",
                    Properties = "{\"Color\": \"black\"}"
                });

                db.SaveChanges();

                db.location.Add(new OGCCodeEF.Model.location()
                {
                    Name = "IISI",
                    Description = "This is IISI",
                    EncodingType = "application/vnd.geo+json",
                    Location = "{\"type\": \"Feature\",geometry\":{ \"type\": \"Point\",\"coordinates\": [25.015548.121.463240]}"
                });

                db.SaveChanges();

                db.historicallocation.Add(new OGCCodeEF.Model.historicallocation()
                {
                    Location_Id = 1,
                    Thing_Id = 1,
                    Time = DateTime.UtcNow
                });

                db.SaveChanges();

                db.sensor.Add(new OGCCodeEF.Model.sensor()
                {
                    Name = "TMP36",
                    Description = "TMP36 - Analog Temperature sensor",
                    EncodingType = "application/pdf",
                    MetaData = "https://www.digikey.tw/product-detail/zh/analog-devices-inc/TMP36-PT7/TMP36-PT7-ND/2700172"
                });

                db.SaveChanges();

                db.observedproperty.Add(new OGCCodeEF.Model.observedproperty()
                {
                    Name = "DewPoint Temperature",
                    Definition = "http://dbpedia.org/page/Dew_point",
                    Description = "The dewpoint temperature is the temperature to which the air must be cooled, at constant pressure, for dew to form. As the grass and other objects near the ground cool to the dewpoint, some of the water vapor in the atmosphere condenses into liquid water on the objects."
                });

                db.SaveChanges();

                db.datastream.Add(new OGCCodeEF.Model.datastream()
                {
                    Name = "烤箱溫度",
                    Description = "This is a datastream measuring the air temperature in an oven.",
                    ObservationType = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Measurement",
                    UnitOfMeasurement = "{\"name\": \"degree Celsius\",\"symbol\": \"°C\",\"definition\": \"http://unitsofmeasure.org/ucum.html#para-30\"}",
                    Thing_Id = 1,
                    Sensor_Id = 1,
                    ObervedProperty_Id = 1
                });

                db.SaveChanges();

                db.featureofinterest.Add(new OGCCodeEF.Model.featureofinterest()
                {
                    Name = "茶水間",
                    Description = "This is located at the IISI.",
                    EncodingType = "application/vnd.geo+json",
                    Feature = "{\"type\": \"Feature\",geometry\":{ \"type\": \"Point\",\"coordinates\": [25.015548.121.463240]}"
                });

                db.SaveChanges();

                db.observation.Add(new OGCCodeEF.Model.observation()
                {
                    Result = "70",
                    ResultQuality = "Describes the quality of the result.",
                    ValidTime = "Time Interval String",
                    Parameters = "Key-value pairs showing the environmental conditions during measurement.",
                    FeatureOflnterest_Id = 1,
                    Datastream_Id = 1,
                    Phenomenon_Time = DateTime.UtcNow,
                    ResultTime = DateTime.UtcNow
                });

                db.SaveChanges();
            }

            #endregion
        }
    }
}
