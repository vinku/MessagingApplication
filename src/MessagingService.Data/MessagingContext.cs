using Microsoft.EntityFrameworkCore;
using MessagingService.Domain;

namespace MessagingService.Data
{
	public class MessaginContext : DbContext
	{
		public MessaginContext(DbContextOptions<MessaginContext> options)
			: base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<UserChat> UserChats { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasKey(s => new { s.UserCellId });

			modelBuilder.Entity<UserChat>()
				.HasKey(s => new { s.UserCellId, s.ChatId });

			modelBuilder.Entity<ChatMessage>()
				.HasKey(s => new { s.ChatId, s.MessageId});

			modelBuilder.Entity<MessageSender>()
				.HasKey(s => new { s.MessageId, s.UserCellId});
			base.OnModelCreating(modelBuilder);
		}
	}
}
