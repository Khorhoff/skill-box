using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Linq;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBotExperiments
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient(System.IO.File.ReadAllText("token.txt"));
        static void Main(string[] args)
        {
            #region ПЗ
            // Создать бота, позволяющего принимать разные типы файлов, 
            // *Научить бота отправлять выбранный файл в ответ
            // 
            // https://data.mos.ru/
            // https://apidata.mos.ru/
            // 
            // https://vk.com/dev
            // https://vk.com/dev/manuals

            // https://dev.twitch.tv/
            // https://discordapp.com/developers/docs/intro
            // https://discordapp.com/developers/applications/
            // https://discordapp.com/verification
            #endregion

            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Message message = update.Message;
                if (message.Document != null)
                {
                    string fileName;
                    string format = message.Document.FileName.ToLower().Split('.').ToList().Last();
                    if (message.Caption != null)
                        fileName = $@"docs\{message.Caption.ToLower()}.{format}";
                    else fileName = $@"docs\{message.Document.FileName.ToLower()}";
                    await PushToCloud(botClient, message, message.Document, fileName, "");
                    await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твой файлик и сохранил под именем {fileName}");
                    return;
                }
                else if (message.Photo != null)
                {
                    if (message.Caption != null)
                    {
                        await PushToCloud(botClient, message, message.Photo[0], $@"photos\{message.Caption.ToLower()}", ".png");
                        await botClient.SendTextMessageAsync(message.Chat, $@"Я скачал твое фото и сохранил в {message.Caption.ToLower()}");
                    }
                    else
                    {
                        await PushToCloud(botClient, message, message.Photo[0], "", "");
                        await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твое фото и сохранил в папку photos");
                    }
                    return;
                }
                else if (message.Video != null)
                {
                    if (message.Caption != null)
                    {
                        await PushToCloud(botClient, message, message.Video, $@"videos\{message.Caption.ToLower()}", ".mp4");
                        await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твое фидео и сохранил под именем {message.Caption.ToLower()}");
                    }
                    else
                    {
                        await PushToCloud(botClient, message, message.Video, "", "");
                        await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твое фидео и сохранил в папку videos");
                    }
                    return;
                }
                else if (message.Audio != null)
                {
                    if (message.Caption != null)
                    {
                        await PushToCloud(botClient, message, message.Audio, $@"music\{message.Caption.ToLower()}", ".mp3");
                        await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твое аудио и сохранил под именем {message.Caption.ToLower()}");
                    }
                    else
                    {
                        await PushToCloud(botClient, message, message.Audio, "", "");
                        await botClient.SendTextMessageAsync(message.Chat, $"Я скачал твое аудио и сохранил в папку music");
                    }
                    return;                }
                else if (message.Text != null)
                {
                    string command;
                    if (message.Text.ToLower().StartsWith("/download"))
                        command = "/download";
                    else if (message.Text.ToLower().StartsWith("/remove"))
                        command = "/remove";
                    else command = message.Text.ToLower();
                    string[] mess;
                    string fileName;
                    switch (command)
                    {
                        case "/start":
                            if (!Directory.Exists($"{message.Chat.FirstName}"))
                            {
                                Directory.CreateDirectory($"{message.Chat.FirstName}");
                                Directory.CreateDirectory($@"{message.Chat.FirstName}\videos");
                                Directory.CreateDirectory($@"{message.Chat.FirstName}\photos");
                                Directory.CreateDirectory($@"{message.Chat.FirstName}\music");
                                Directory.CreateDirectory($@"{message.Chat.FirstName}\docs");
                            }
                            await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать, {message.Chat.FirstName}!\n" +
                                $"Я создал для тебя папочку, где буду хранить твои файлы.\n" +
                                $"Чтобы посмотреть список команд, отправь мне '/help'.");
                            return;
                        case "/view":
                            await GetCloudView(botClient, message);
                            return;
                        case "/download":
                            mess = message.Text.ToLower().Split(' ');
                            if (mess.Length == 1 || mess[1] == "")
                            {
                                await botClient.SendTextMessageAsync(message.Chat, $"Введи имя файла через 1 пробел после команды");
                                return;
                            }
                            if (mess.Length > 2)
                                fileName = GetFileName(mess);
                            else fileName = mess[1];
                            await DownloadFromCloud(botClient, message, fileName);
                            return;
                        case "/help":
                            await botClient.SendTextMessageAsync(message.Chat, $"Вот список команд:\n" +
                            $"/view - посмотреть файлы в хранилище;\n" +
                            $"/download [имя файла] - скачать выбранный файл;\n" +
                            $"Для того чтобы добавить файл в хранилище просто пришли его мне, " +
                            $"а если хочешь назвать его как-то по своему, то добавь описание к нему.\n\n" +
                            $"P.S. Если хочешь назвать файлы, то отправляй их по одному!");
                            return;
                        default:
                            await botClient.SendTextMessageAsync(message.Chat, "Такой команды нет. Отправь мне '/help' чтобы посмотреть список команд");
                            return;
                    }
                }
            }
        }

        private static async Task DownloadFromCloud(ITelegramBotClient botClient, Message message, string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{message.Chat.FirstName}");
            foreach (var dir in directoryInfo.GetDirectories())
                foreach (var file in dir.GetFiles())
                    if (file.Name == path)
                        using (var stream = System.IO.File.OpenRead($@"{message.Chat.FirstName}\{dir.Name}\{file.Name}"))
                        {
                            InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                            inputOnlineFile.FileName = file.Name;
                            await botClient.SendDocumentAsync(message.Chat, inputOnlineFile);
                            return;
                        }
            await botClient.SendTextMessageAsync(message.Chat, "Файл не найден");

        }

        private static async Task GetCloudView(ITelegramBotClient botClient, Message message)
        {
            string fileList = "";
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{message.Chat.FirstName}\docs");
            foreach (var file in directoryInfo.GetFiles())
            {
                fileList += $"{file.Name}\n";
            }
            await botClient.SendTextMessageAsync(message.Chat, $"Документы:\n{((fileList != "") ? fileList : "Нет файлов")}");

            fileList = "";
            directoryInfo = new DirectoryInfo($@"{message.Chat.FirstName}\photos");
            foreach (var file in directoryInfo.GetFiles())
            {
                fileList += $"{file.Name}\n";
            }
            await botClient.SendTextMessageAsync(message.Chat, $"Фото:\n{((fileList != "") ? fileList : "Нет фото")}");

            fileList = "";
            directoryInfo = new DirectoryInfo($@"{message.Chat.FirstName}\videos");
            foreach (var file in directoryInfo.GetFiles())
            {
                fileList += $"{file.Name}\n";
            }
            await botClient.SendTextMessageAsync(message.Chat, $"Видео:\n{((fileList != "") ? fileList : "Нет видео")}");

            fileList = "";
            directoryInfo = new DirectoryInfo($@"{message.Chat.FirstName}\music");
            foreach (var file in directoryInfo.GetFiles())
            {
                fileList += $"{file.Name}\n";
            }
            await botClient.SendTextMessageAsync(message.Chat, $"Музыка:\n{((fileList != "") ? fileList : "Нет музыки")}");
        }

        private static async Task<string> PushToCloud(ITelegramBotClient botClient, Message message, FileBase file, string fileName, string format)
        { 
            Telegram.Bot.Types.File doc = await botClient.GetFileAsync(file.FileId);
            if (fileName == "")
                fileName = doc.FilePath.ToLower() + format;
            else fileName += format;
            using (FileStream fs = new FileStream($@"{message.Chat.FirstName}\{fileName}", FileMode.Create))
                await botClient.DownloadFileAsync(doc.FilePath, fs);
            return fileName;
        }

        private static string GetFileName(string[] mess)
        {
            string fileName = "";
            for (int i = 1; i < mess.Length; i++)
            {
                fileName += mess[i] + " ";
            }
            return fileName;
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


    }
}
