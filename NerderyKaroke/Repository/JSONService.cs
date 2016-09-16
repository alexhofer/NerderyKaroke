using NerderyKaroke.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NerderyKaroke.Repository
{
    public static class JSONService
    {
        public static List<SongModel> GetSongList()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            var songList = JsonConvert.DeserializeObject<List<SongModel>>(stream);

            if (songList != null)
                return songList;
            else
                return new List<SongModel>();

        }

        public static void AddEntry(SongModel model)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            List<SongModel> songList = JsonConvert.DeserializeObject<List<SongModel>>(stream);

            if (songList == null)
                songList = new List<SongModel>();

            songList.Add(model);

            File.WriteAllText(FILEPATH, JsonConvert.SerializeObject(songList));
        }

        public static void UpdateEntry(int id, SongModel model)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            var songList = JsonConvert.DeserializeObject<List<SongModel>>(stream);

            var editedModel = songList.Where(x => x.Id == id).FirstOrDefault();

            if (editedModel != null)
            {
                model.SingerName = editedModel.SingerName;
                model.SongTitle = editedModel.SongTitle;
            }

            File.WriteAllText(FILEPATH, JsonConvert.SerializeObject(songList));
        }

        public static void DeleteEntry(int id)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            var songList = JsonConvert.DeserializeObject<List<SongModel>>(stream);

            var itemToRemove = songList.Single(x => x.Id == id);
            songList.Remove(itemToRemove);

            File.WriteAllText(FILEPATH, JsonConvert.SerializeObject(songList));
        }

        public static void DeleteAll()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            File.WriteAllText(FILEPATH, "");
        }
    }
}