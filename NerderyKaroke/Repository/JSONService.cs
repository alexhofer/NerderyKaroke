using NerderyKaroke.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NerderyKaroke.Repository
{
    public static class JSONService
    {
        public static List<Song> GetSongList()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            var songList = JsonConvert.DeserializeObject<List<Song>>(stream);

            if (songList != null)
                return songList;
            else
                return new List<Song>();

        }

        public static void AddEntry(Song model)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            List<Song> songList = JsonConvert.DeserializeObject<List<Song>>(stream);

            if (songList == null)
                songList = new List<Song>();

            songList.Add(model);

            File.WriteAllText(FILEPATH, JsonConvert.SerializeObject(songList));
        }

        public static void UpdateEntry(int id, Song model)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            var stream = File.ReadAllText(FILEPATH);

            var songList = JsonConvert.DeserializeObject<List<Song>>(stream);

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

            var songList = JsonConvert.DeserializeObject<List<Song>>(stream);

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