using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace TESTERforWNDFORMS
{
    static class TelegramBot
    {
        private static string TockenOfTB { get; } = "1983164036:AAGCme7Gc9ztfP3M51cuFiZ_XDei3K8QU3I";
        private static TelegramBotClient Client { get; set; }
        public static string link { get; set; }
        public static string pairID { get; set; }
        private static long ChatID { get; set; } = 0;

        [Obsolete]
        public static void InisaliaseBot ()
        {
            try
            {
                Client = new TelegramBotClient(TockenOfTB);
                Client.StartReceiving();
                Client.OnMessage += OnMessageHandler;
            }
            catch
            {

            }
        }

        [Obsolete]
        private static void OnMessageHandler (object sender , MessageEventArgs e)
        {
            try
            {
                var Msg = e.Message;
                ChatID = Msg.Chat.Id;
                if(Msg.Text != null)
                {
                    switch(Msg.Text)
                    {
                        case "Refresh":
                            SendAllTechInfo(e);
                            break;


                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        [Obsolete]
        private static async void SendAllTechInfo (MessageEventArgs e)
        {
            try
            {
                    var Msg = e.Message;
                    string text = "";
                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FiveMin , pairID) , out string[] parsing , out string sum);
                    if(parsing != null && sum != null)
                        text += "5 минут: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FefteenMin , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "15 минут: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FirtyMin , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "30 минут: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneHour , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "1 час: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FiveHours , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "5 часов: " + sum + "\r\n";


                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneDay , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "1 день: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneWeek , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "1 неделя: " + sum + "\r\n";

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneMonth , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        text += "1 месяц: " + sum + "\r\n";
                    await Client.SendTextMessageAsync(Msg.Chat.Id , text , replyMarkup: GetButtons());
            }
            catch
            {
            }
        }
        public static async void SendPlusPersent ()
        {
            try
            {
                if(ChatID != 0)
                {
                    await Client.SendTextMessageAsync(ChatID , "Валюта поднялась на 1%" + "\r\n" + "Было: " + ItsTimeToStop.BeforeCourse + "\r\n" + "Стало: " + ItsTimeToStop.ThisNowCourse , replyMarkup: GetButtons());
                }
            }
            catch
            {
            }
        }

        public static async void SendMinusPersent ()
        {
            try
            {
                if(ChatID != 0)
                {
                    await Client.SendTextMessageAsync(ChatID , "Валюта упала на 1%" + "\r\n" + "Было: " + ItsTimeToStop.BeforeCourse + "\r\n" + "Стало: " + ItsTimeToStop.ThisNowCourse , replyMarkup: GetButtons());
                }
            }
            catch
            {
            }
        }

        [Obsolete]
        public static void StopReciving()
        {
            Client.StopReceiving();
        }


        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Refresh" }}
                }
            };
        }
    }
}
