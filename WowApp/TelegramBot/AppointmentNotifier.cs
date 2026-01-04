using Microsoft.Extensions.Options;

using System.Text;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;

using WowApp.EntityModels;
using WowApp.ModelsDTOs;

namespace WowApp.TelegramBot
{
    public class AppointmentNotifier
    {
        private readonly ITelegramBotClient _bot;
        private readonly TelegramOptions _cfg;

        public AppointmentNotifier(ITelegramBotClient bot, IOptions<TelegramOptions> cfg)
        {
            _bot = bot;
            _cfg = cfg.Value;
        }

        public async Task NotifyNewAppointmentAsync(Appointment appointment,
                                                    long? overrideChatId = null,
                                                    CancellationToken ct = default)
        {
            if (appointment is null) return;

            var chatId = overrideChatId ?? _cfg.AdminChatId;

            var name = string.IsNullOrWhiteSpace(appointment.ClientName) ? "—" : appointment.ClientName;
            var phone = string.IsNullOrWhiteSpace(appointment.ClientPhone) ? "—" : appointment.ClientPhone;
            var msg = string.IsNullOrWhiteSpace(appointment.Message) ? "—" : appointment.Message;
            var group = string.IsNullOrWhiteSpace(appointment.Group) ? "—" : appointment.Group;
            var service = string.IsNullOrWhiteSpace(appointment.ServiceTitle) ? "—" : appointment.ServiceTitle;

            var dateText = appointment.AppointmentDate != default
                ? appointment.AppointmentDate.ToString("dd.MM.yyyy")
                : "—";

            var cultureText = appointment.IsCulture ? "EN 🇬🇧" : "UA 🇺🇦";

            var text = new StringBuilder()
                .AppendLine("📩 *Нова заявка на запис!*")
                .AppendLine($"🆔 ID: *{appointment.Id}*")
                .AppendLine($"👤 Клієнт: *{Esc(name)}*")
                .AppendLine($"📞 Телефон: `{Esc(phone)}`")
                .AppendLine($"📅 Дата: *{dateText}*")
                .AppendLine($"🏷️ Напрям/група: *{Esc(group)}*")
                .AppendLine($"🧾 Послуга: *{Esc(service)}*")                
                .AppendLine($"💬 Повідомлення: *{Esc(msg)}*")
                .ToString();

            try
            {
                await _bot.SendMessage(
                    chatId: chatId,
                    text: text,
                    parseMode: ParseMode.Markdown,
                    cancellationToken: ct
                );
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error sending appointment notification: {ex.Message}");
            }
        }

        public async Task NotifyNewCallbackAsync(
                                                CallbackCreateDto req,
                                                long? overrideChatId = null,
                                                CancellationToken ct = default)
            {
                var chatId = overrideChatId ?? _cfg.AdminChatId;
                var text =
                   $"""
                    📞 *Новий запит на зворотній дзвінок*
                    🆔 ID: *{req.Id}*
                    👤 Ім’я: *{Esc(req.ClientName)}*
                    📞 Телефон: `{Esc(req.ClientPhone)}`
                    💬 Коментар: *{Esc(req.Message ?? "—")}*                   
                    """;

            await _bot.SendMessage(chatId, text, parseMode: ParseMode.Markdown, cancellationToken: ct);
        }

        public async Task NotifyNewReviewAsync(
                                            Review req,
                                            long? overrideChatId = null,
                                            CancellationToken ct = default)
        {
            var chatId = overrideChatId ?? _cfg.AdminChatId;

            var stars = new string('⭐', Math.Clamp(req.Rating, 1, 5));

            var text =
                $"""
                    ✍️ *Новий відгук*
                    🆔 ID: *{req.Id}*
                    👤 Ім’я: *{Esc(req.ClientName)}*
                    ⭐ Оцінка: *{stars}* ({req.Rating}/5)
                    📅 Дата: *{req.ReviewDate:dd.MM.yyyy}*

                    💬 *Відгук:*
                    _{Esc(req.Content)}_
                    """;

            await _bot.SendMessage(
                chatId,
                text,
                parseMode: ParseMode.Markdown,
                cancellationToken: ct);
        }


        private static string Esc(string s) => s
           .Replace("_", "\\_").Replace("*", "\\*").Replace("[", "\\[").Replace("`", "\\`");
    }
}
