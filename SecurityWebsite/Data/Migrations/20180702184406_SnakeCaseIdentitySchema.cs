using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SecurityWebsite.Data.Migrations
{
    public partial class SnakeCaseIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                "PK_AspNetUsers",
                "AspNetUsers");

            migrationBuilder.RenameTable(
                "AspNetUsers",
                newName: "asp_net_users");

            migrationBuilder.RenameColumn(
                "UserName",
                "asp_net_users",
                "user_name");

            migrationBuilder.RenameColumn(
                "TwoFactorEnabled",
                "asp_net_users",
                "two_factor_enabled");

            migrationBuilder.RenameColumn(
                "SecurityStamp",
                "asp_net_users",
                "security_stamp");

            migrationBuilder.RenameColumn(
                "PhoneNumberConfirmed",
                "asp_net_users",
                "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                "PhoneNumber",
                "asp_net_users",
                "phone_number");

            migrationBuilder.RenameColumn(
                "PasswordHash",
                "asp_net_users",
                "password_hash");

            migrationBuilder.RenameColumn(
                "NormalizedUserName",
                "asp_net_users",
                "normalized_user_name");

            migrationBuilder.RenameColumn(
                "NormalizedEmail",
                "asp_net_users",
                "normalized_email");

            migrationBuilder.RenameColumn(
                "LockoutEnd",
                "asp_net_users",
                "lockout_end");

            migrationBuilder.RenameColumn(
                "LockoutEnabled",
                "asp_net_users",
                "lockout_enabled");

            migrationBuilder.RenameColumn(
                "EmailConfirmed",
                "asp_net_users",
                "email_confirmed");

            migrationBuilder.RenameColumn(
                "Email",
                "asp_net_users",
                "email");

            migrationBuilder.RenameColumn(
                "ConcurrencyStamp",
                "asp_net_users",
                "concurrency_stamp");

            migrationBuilder.RenameColumn(
                "AccessFailedCount",
                "asp_net_users",
                "access_failed_count");

            migrationBuilder.RenameColumn(
                "Id",
                "asp_net_users",
                "id");

            migrationBuilder.RenameIndex(
                "UserNameIndex",
                table: "asp_net_users",
                newName: "user_name_index");

            migrationBuilder.RenameIndex(
                "EmailIndex",
                table: "asp_net_users",
                newName: "email_index");

            migrationBuilder.AddColumn<bool>(
                "active",
                "asp_net_users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                "pk_asp_net_users",
                "asp_net_users",
                "id");

            migrationBuilder.CreateTable(
                "asp_net_roles",
                table => new
                {
                    id = table.Column<string>(nullable: false),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table => { table.PrimaryKey("pk_asp_net_roles", x => x.id); });

            migrationBuilder.CreateTable(
                "asp_net_user_claims",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        "fk_asp_net_user_claims_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_logins",
                table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new {x.login_provider, x.provider_key});
                    table.ForeignKey(
                        "fk_asp_net_user_logins_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_tokens",
                table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new {x.user_id, x.login_provider, x.name});
                    table.ForeignKey(
                        "fk_asp_net_user_tokens_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_role_claims",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true),
                    role_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        "fk_asp_net_role_claims_asp_net_roles_role_id",
                        x => x.role_id,
                        "asp_net_roles",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_roles",
                table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    role_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new {x.user_id, x.role_id});
                    table.ForeignKey(
                        "fk_asp_net_user_roles_asp_net_roles_role_id",
                        x => x.role_id,
                        "asp_net_roles",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "fk_asp_net_user_roles_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "ix_asp_net_role_claims_role_id",
                "asp_net_role_claims",
                "role_id");

            migrationBuilder.CreateIndex(
                "role_name_index",
                "asp_net_roles",
                "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_claims_user_id",
                "asp_net_user_claims",
                "user_id");

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_logins_user_id",
                "asp_net_user_logins",
                "user_id");

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_roles_role_id",
                "asp_net_user_roles",
                "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "asp_net_role_claims");

            migrationBuilder.DropTable(
                "asp_net_user_claims");

            migrationBuilder.DropTable(
                "asp_net_user_logins");

            migrationBuilder.DropTable(
                "asp_net_user_roles");

            migrationBuilder.DropTable(
                "asp_net_user_tokens");

            migrationBuilder.DropTable(
                "asp_net_roles");

            migrationBuilder.DropPrimaryKey(
                "pk_asp_net_users",
                "asp_net_users");

            migrationBuilder.DropColumn(
                "active",
                "asp_net_users");

            migrationBuilder.RenameTable(
                "asp_net_users",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                "user_name",
                "AspNetUsers",
                "UserName");

            migrationBuilder.RenameColumn(
                "two_factor_enabled",
                "AspNetUsers",
                "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                "security_stamp",
                "AspNetUsers",
                "SecurityStamp");

            migrationBuilder.RenameColumn(
                "phone_number_confirmed",
                "AspNetUsers",
                "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                "phone_number",
                "AspNetUsers",
                "PhoneNumber");

            migrationBuilder.RenameColumn(
                "password_hash",
                "AspNetUsers",
                "PasswordHash");

            migrationBuilder.RenameColumn(
                "normalized_user_name",
                "AspNetUsers",
                "NormalizedUserName");

            migrationBuilder.RenameColumn(
                "normalized_email",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.RenameColumn(
                "lockout_end",
                "AspNetUsers",
                "LockoutEnd");

            migrationBuilder.RenameColumn(
                "lockout_enabled",
                "AspNetUsers",
                "LockoutEnabled");

            migrationBuilder.RenameColumn(
                "email_confirmed",
                "AspNetUsers",
                "EmailConfirmed");

            migrationBuilder.RenameColumn(
                "email",
                "AspNetUsers",
                "Email");

            migrationBuilder.RenameColumn(
                "concurrency_stamp",
                "AspNetUsers",
                "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                "access_failed_count",
                "AspNetUsers",
                "AccessFailedCount");

            migrationBuilder.RenameColumn(
                "id",
                "AspNetUsers",
                "Id");

            migrationBuilder.RenameIndex(
                "user_name_index",
                table: "AspNetUsers",
                newName: "UserNameIndex");

            migrationBuilder.RenameIndex(
                "email_index",
                table: "AspNetUsers",
                newName: "EmailIndex");

            migrationBuilder.AddPrimaryKey(
                "PK_AspNetUsers",
                "AspNetUsers",
                "Id");

            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_UserId",
                "AspNetUserRoles",
                "UserId");
        }
    }
}