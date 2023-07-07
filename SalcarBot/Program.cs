// http://t.me/MySalcarBot
// 6070205489:AAF3CH6DUZg7IRtWj-WCSTkv-MWm497urL4

using Newtonsoft.Json;
using SalcarBot.Models;
using SwansonParser2023;
using SwansonParser2023.Models;
using SwansonParser2023.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

var token = "6070205489:AAF3CH6DUZg7IRtWj-WCSTkv-MWm497urL4";
var bot = new TelegramBotClient(token);
var name = bot.GetMeAsync().Result.FirstName;

var cts = new CancellationTokenSource();
var core = new BotCode(new ProductsContext(), new ExcelProductWriter());

var msg = "What's the time?";
var time = DateTimeOffset.UtcNow;

Console.WriteLine(name);

bot.StartReceiving(
    core.HandleUpdate,
    // error handling
    async (bot, exception, cancellationToken) =>
    {
        await Console.Out.WriteLineAsync($"{exception.Message}");
    },
    // option
    new Telegram.Bot.Polling.ReceiverOptions { AllowedUpdates = { } },
    // cancellation token
    cts.Token
    );

Console.ReadLine();


// update handling
////async (bot, update, cancellationToken) =>
////{
////    await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(update));
////    if (update.Message != null && update.Message.Text == msg)
////    {
////        await bot.SendTextMessageAsync(update.Message.Chat, time.ToString());
////    }
////    if (update.Message != null)
////    {       //chatbot reply after writing something
////        //await bot.SendTextMessageAsync(update.Message.Chat, "Welcome to this chat!");

////            //'typing' action from chatbot with delay 2 sec
////        //await bot.SendChatActionAsync(
////        //    chatId: update.Message.Chat.Id,
////        //    chatAction: Telegram.Bot.Types.Enums.ChatAction.Typing
////        //    );
////        //await Task.Delay(2000);
////            //send files
////        //var file = "C:\\Users\\stran\\Desktop\\SwansonParser2023\\bin\\Debug\\net6.0\\products.xlsx";
////        //await using Stream stream = System.IO.File.OpenWrite(file);
////        //await bot.SendDocumentAsync(
////        //    chatId: update.Message.Chat.Id,
////        //    document: InputFile.FromStream(stream, file),
////        //    caption: "Product list"
////        //    );
////            //send photo with caption
////        //await bot.SendPhotoAsync(
////        //    chatId: update.Message.Chat.Id,
////        //    photo: InputFile.FromUri("https://media.swansonvitamins.com/images/items/master/SW1876.jpg"),
////        //    caption: $"<b>Swanson Premium- Multi withIron + Stress Relief</b>\n" +
////        //    "$15.99\n" +
////        //    "<a href=\"https://www.swansonvitamins.com/p/swanson-premium-multi-iron-stress-relief-60-tabs\">Open</a>\n",
////        //    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
////        //    replyMarkup: new InlineKeyboardMarkup(
////        //        InlineKeyboardButton.WithUrl(
////        //            text: "Open website",
////        //            url: "https://www.swansonvitamins.com/p/swanson-premium-multi-iron-stress-relief-60-tabs"))
////        //    );

////        //var product = new ProductsContext().Products.FirstOrDefault(y => y.Code == update.Message.Text);
////        //await bot.SendPhotoAsync(
////        //    chatId: update.Message.Chat.Id,
////        //    photo: InputFile.FromUri($"{product.ImageUrl}"),
////        //    caption: $"{product.Title}\n" +
////        //    $"{product.Price}\n" +
////        //    $"{product.FullUrl}\n",
////        //    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
////        //    );
////    }
////},
