﻿// <auto-generated />
using System;
using MessagingService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessagingService.Data.Migrations
{
    [DbContext(typeof(MessaginContext))]
    [Migration("20190929035654_Messages")]
    partial class Messages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MessagingService.Domain.Chat", b =>
                {
                    b.Property<Guid>("ChatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastActivityTime");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MessagingService.Domain.ChatMessage", b =>
                {
                    b.Property<Guid>("ChatId");

                    b.Property<Guid>("MessageId");

                    b.HasKey("ChatId", "MessageId");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("MessagingService.Domain.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MessageText");

                    b.Property<DateTime>("SentTime");

                    b.Property<int>("Status");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessagingService.Domain.MessageSender", b =>
                {
                    b.Property<Guid>("MessageId");

                    b.Property<string>("UserCellId");

                    b.HasKey("MessageId", "UserCellId");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("UserCellId");

                    b.ToTable("MessageSenders");
                });

            modelBuilder.Entity("MessagingService.Domain.User", b =>
                {
                    b.Property<string>("UserCellId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastSeenTime");

                    b.Property<string>("Name");

                    b.HasKey("UserCellId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessagingService.Domain.UserChat", b =>
                {
                    b.Property<string>("UserCellId");

                    b.Property<Guid>("ChatId");

                    b.HasKey("UserCellId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("UserChats");
                });

            modelBuilder.Entity("MessagingService.Domain.ChatMessage", b =>
                {
                    b.HasOne("MessagingService.Domain.Chat", "Chat")
                        .WithMany("ChatMessages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MessagingService.Domain.Message", "Message")
                        .WithOne("ChatMessage")
                        .HasForeignKey("MessagingService.Domain.ChatMessage", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MessagingService.Domain.MessageSender", b =>
                {
                    b.HasOne("MessagingService.Domain.Message", "Message")
                        .WithOne("MessageSender")
                        .HasForeignKey("MessagingService.Domain.MessageSender", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MessagingService.Domain.User", "Sender")
                        .WithMany()
                        .HasForeignKey("UserCellId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MessagingService.Domain.UserChat", b =>
                {
                    b.HasOne("MessagingService.Domain.Chat", "Chat")
                        .WithMany("UserChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MessagingService.Domain.User", "User")
                        .WithMany("UserChats")
                        .HasForeignKey("UserCellId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
