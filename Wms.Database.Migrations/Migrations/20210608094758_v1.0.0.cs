using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wms.Database.Migrations.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_app",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "是否默认激活"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_app", x => x.Id);
                },
                comment: "系统应用表");

            migrationBuilder.CreateTable(
                name: "sys_dict_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict_type", x => x.Id);
                },
                comment: "字典类型表");

            migrationBuilder.CreateTable(
                name: "sys_emp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    JobNum = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "工号"),
                    OrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id"),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "机构名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp", x => x.Id);
                },
                comment: "员工表");

            migrationBuilder.CreateTable(
                name: "sys_file",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    FileLocation = table.Column<int>(type: "int", nullable: false, comment: "文件存储位置"),
                    FileBucket = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件仓库"),
                    FileOriginName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件名称"),
                    FileSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件后缀"),
                    FileSizeKb = table.Column<long>(type: "bigint", nullable: false, comment: "文件大小kb"),
                    FileSizeInfo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件大小信息"),
                    FileObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "存储到bucket的名称"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "存储路径"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file", x => x.Id);
                },
                comment: "文件信息表");

            migrationBuilder.CreateTable(
                name: "sys_log_audit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "表名"),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "列名"),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "新值"),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "旧值"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "操作时间"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "操作人Id"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "操作人名称"),
                    Operate = table.Column<int>(type: "int", nullable: false, comment: "操作方式")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_audit", x => x.Id);
                },
                comment: "审计日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_ex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "操作人"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "类名"),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "方法名"),
                    ExceptionName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "异常名称"),
                    ExceptionMsg = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "异常信息"),
                    ExceptionSource = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "异常源"),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true, comment: "堆栈信息"),
                    ParamsObj = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true, comment: "参数对象"),
                    ExceptionTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "异常时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_ex", x => x.Id);
                },
                comment: "异常日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_op",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Success = table.Column<int>(type: "int", nullable: false, comment: "是否执行成功"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "具体消息"),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "IP"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "地址"),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "浏览器"),
                    Os = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "操作系统"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "请求地址"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "类名称"),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "方法名称"),
                    ReqMethod = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "请求方式"),
                    Param = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "请求参数"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "返回结果"),
                    ElapsedTime = table.Column<long>(type: "bigint", nullable: false, comment: "耗时"),
                    OpTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "操作时间"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "操作人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_op", x => x.Id);
                },
                comment: "操作日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_vis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Success = table.Column<int>(type: "int", nullable: false, comment: "是否执行成功"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "具体消息"),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "IP"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "地址"),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "浏览器"),
                    Os = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "操作系统"),
                    VisType = table.Column<int>(type: "int", nullable: false, comment: "访问类型"),
                    VisTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "访问时间"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "访问人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_vis", x => x.Id);
                },
                comment: "访问日志表");

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Pids = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "父Ids"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "菜单类型"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "图标"),
                    Router = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "路由地址"),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "组件地址"),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "权限标识"),
                    Application = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "应用分类"),
                    OpenType = table.Column<int>(type: "int", nullable: false, comment: "打开方式"),
                    Visible = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "是否可见"),
                    Weight = table.Column<int>(type: "int", nullable: false, comment: "权重"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu", x => x.Id);
                },
                comment: "菜单表");

            migrationBuilder.CreateTable(
                name: "sys_oauth_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "UUID"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Token"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "昵称"),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "头像"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "性别"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "电话"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "邮箱"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "位置"),
                    Blog = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户网址"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "所在公司"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户来源"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_oauth_user", x => x.Id);
                },
                comment: "Oauth登录用户表");

            migrationBuilder.CreateTable(
                name: "sys_org",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Pids = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "父Ids"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "联系人"),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "电话"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_org", x => x.Id);
                },
                comment: "组织机构表");

            migrationBuilder.CreateTable(
                name: "sys_pos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_pos", x => x.Id);
                },
                comment: "职位表");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    DataScopeType = table.Column<int>(type: "int", nullable: false, comment: "数据范围类型"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.Id);
                },
                comment: "角色表");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Account = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "账号"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "密码"),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "昵称"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "姓名"),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "头像"),
                    Birthday = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "生日"),
                    Sex = table.Column<int>(type: "int", nullable: false, comment: "性别-男_1、女_2"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "邮箱"),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "手机"),
                    Tel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "电话"),
                    LastLoginIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "最后登录IP"),
                    LastLoginTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后登录时间"),
                    AdminType = table.Column<int>(type: "int", nullable: false, comment: "管理员类型-超级管理员_1、非管理员_2"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态-正常_0、停用_1、删除_2"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                },
                comment: "用户表");

            migrationBuilder.CreateTable(
                name: "sys_dict_data",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    TypeId = table.Column<long>(type: "bigint", nullable: false, comment: "字典类型Id"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "值"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    ModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_dict_data_sys_dict_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "sys_dict_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "字典值表");

            migrationBuilder.CreateTable(
                name: "sys_emp_ext_org_pos",
                columns: table => new
                {
                    SysEmpId = table.Column<long>(type: "bigint", nullable: false, comment: "员工Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id"),
                    SysPosId = table.Column<long>(type: "bigint", nullable: false, comment: "职位Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp_ext_org_pos", x => new { x.SysEmpId, x.SysOrgId, x.SysPosId });
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_emp_SysEmpId",
                        column: x => x.SysEmpId,
                        principalTable: "sys_emp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_pos_SysPosId",
                        column: x => x.SysPosId,
                        principalTable: "sys_pos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工附属机构职位表");

            migrationBuilder.CreateTable(
                name: "sys_emp_pos",
                columns: table => new
                {
                    SysEmpId = table.Column<long>(type: "bigint", nullable: false, comment: "员工Id"),
                    SysPosId = table.Column<long>(type: "bigint", nullable: false, comment: "职位Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp_pos", x => new { x.SysEmpId, x.SysPosId });
                    table.ForeignKey(
                        name: "FK_sys_emp_pos_sys_emp_SysEmpId",
                        column: x => x.SysEmpId,
                        principalTable: "sys_emp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_pos_sys_pos_SysPosId",
                        column: x => x.SysPosId,
                        principalTable: "sys_pos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工职位表");

            migrationBuilder.CreateTable(
                name: "sys_role_data_scope",
                columns: table => new
                {
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_data_scope", x => new { x.SysRoleId, x.SysOrgId });
                    table.ForeignKey(
                        name: "FK_sys_role_data_scope_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_role_data_scope_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色数据范围表");

            migrationBuilder.CreateTable(
                name: "sys_role_menu",
                columns: table => new
                {
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    SysMenuId = table.Column<long>(type: "bigint", nullable: false, comment: "菜单Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_menu", x => new { x.SysRoleId, x.SysMenuId });
                    table.ForeignKey(
                        name: "FK_sys_role_menu_sys_menu_SysMenuId",
                        column: x => x.SysMenuId,
                        principalTable: "sys_menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_role_menu_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色菜单表");

            migrationBuilder.CreateTable(
                name: "sys_user_data_scope",
                columns: table => new
                {
                    SysUserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_data_scope", x => new { x.SysUserId, x.SysOrgId });
                    table.ForeignKey(
                        name: "FK_sys_user_data_scope_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_data_scope_sys_user_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户数据范围表");

            migrationBuilder.CreateTable(
                name: "sys_user_role",
                columns: table => new
                {
                    SysUserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_role", x => new { x.SysUserId, x.SysRoleId });
                    table.ForeignKey(
                        name: "FK_sys_user_role_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_role_sys_user_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色表");

            migrationBuilder.InsertData(
                table: "sys_app",
                columns: new[] { "Id", "Active", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Sort", "Status" },
                values: new object[,]
                {
                    { 142307070902341L, "Y", "system_manage", null, null, false, null, null, "系统管理", 100, 0 },
                    { 142307070922869L, "N", "busapp", null, null, false, null, null, "业务应用", 200, 0 }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_type",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Remark", "Sort", "Status" },
                values: new object[,]
                {
                    { 142307070922828L, "code_gen_query_type", null, null, false, null, null, "代码生成查询类型", "代码生成查询类型", 100, 0 },
                    { 142307070922827L, "code_gen_effect_type", null, null, false, null, null, "代码生成作用类型", "代码生成作用类型", 100, 0 },
                    { 142307070910538L, "request_type", null, null, false, null, null, "请求方式", "请求方式", 100, 0 },
                    { 142307070910537L, "code_gen_create_type", null, null, false, null, null, "代码生成方式", "代码生成方式", 100, 0 },
                    { 142307070910536L, "yes_true_false", null, null, false, null, null, "是否boolean", "是否boolean", 100, 0 },
                    { 142307070910535L, "notice_status", null, null, false, null, null, "通知公告状态", "通知公告状态", 100, 0 },
                    { 142307070910534L, "notice_type", null, null, false, null, null, "通知公告类型", "通知公告类型", 100, 0 },
                    { 142307070910533L, "run_status", null, null, false, null, null, "运行状态", "定时任务运行状态", 100, 0 },
                    { 142307070906495L, "file_storage_location", null, null, false, null, null, "文件存储位置", "文件存储位置", 100, 0 },
                    { 142307070906494L, "op_type", null, null, false, null, null, "操作类型", "操作类型", 100, 0 },
                    { 142307070906493L, "sms_send_source", null, null, false, null, null, "短信发送来源", "短信发送来源", 100, 0 },
                    { 142307070906492L, "data_scope_type", null, null, false, null, null, "数据范围类型", "数据范围类型", 100, 0 },
                    { 142307070906491L, "menu_weight", null, null, false, null, null, "菜单权重", "菜单权重", 100, 0 },
                    { 142307070906490L, "open_type", null, null, false, null, null, "打开方式", "打开方式", 100, 0 },
                    { 142307070906489L, "send_type", null, null, false, null, null, "发送类型", "发送类型", 100, 0 },
                    { 142307070906488L, "menu_type", null, null, false, null, null, "菜单类型", "菜单类型", 100, 0 },
                    { 142307070906487L, "vis_type", null, null, false, null, null, "访问类型", "访问类型", 100, 0 },
                    { 142307070906486L, "yes_or_no", null, null, false, null, null, "是否", "是否", 100, 0 },
                    { 142307070906485L, "consts_type", null, null, false, null, null, "常量的分类", "常量的分类，用于区别一组配置", 100, 0 },
                    { 142307070906484L, "sex", null, null, false, null, null, "性别", "性别字典", 100, 0 },
                    { 142307070906483L, "common_status", null, null, false, null, null, "通用状态", "通用状态", 100, 0 },
                    { 142307070922829L, "code_gen_net_type", null, null, false, null, null, "代码生成.NET类型", "代码生成.NET类型", 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "sys_emp",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "IsDeleted", "JobNum", "ModifyTime", "ModifyUserId", "OrgId", "OrgName" },
                values: new object[,]
                {
                    { 142307070910552L, null, null, false, "D1002", null, null, 142307070910539L, "WS集团" },
                    { 142307070910551L, null, null, false, "D1001", null, null, 142307070910539L, "WS集团" }
                });

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "Icon", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "OpenType", "Permission", "Pid", "Pids", "Remark", "Router", "Sort", "Status", "Type", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070910612L, "system", "sys_dict_mgr_dict_type_edit", null, null, null, null, false, null, null, "字典类型编辑", 0, "sysDictType:edit", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910812L, "system", "sys_menu_mgr", "system/menu/index", null, null, null, false, null, null, "菜单管理", 1, null, 142307070910811L, "[0],[142307070910811],", null, "/menu", 100, 0, 1, "Y", 1 },
                    { 142307070910811L, "system", "system_tools", "", null, null, "layui-icon layui-icon-component", false, null, null, "开发管理", 0, null, 0L, "[0],", null, "/tools", 100, 0, 0, "Y", 1 },
                    { 142307070910630L, "system", "sys_file_mgr_sys_file_preview", null, null, null, null, false, null, null, "图片预览", 0, "sysFileInfo:preview", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910629L, "system", "sys_file_mgr_sys_file_download", null, null, null, null, false, null, null, "文件下载", 0, "sysFileInfo:download", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910628L, "system", "sys_file_mgr_sys_file_upload", null, null, null, null, false, null, null, "文件上传", 0, "sysFileInfo:upload", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910627L, "system", "sys_file_mgr_sys_file_detail", null, null, null, null, false, null, null, "文件详情", 0, "sysFileInfo:detail", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910626L, "system", "sys_file_mgr_sys_file_delete", null, null, null, null, false, null, null, "文件删除", 0, "sysFileInfo:delete", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910625L, "system", "sys_file_mgr_sys_file_list", null, null, null, null, false, null, null, "文件列表", 0, "sysFileInfo:list", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910624L, "system", "sys_file_mgr_sys_file_page", null, null, null, null, false, null, null, "文件查询", 0, "sysFileInfo:page", 142307070910623L, "[0],[142307070910563],[142307070910623],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910813L, "system", "sys_menu_mgr_list", null, null, null, null, false, null, null, "菜单列表", 0, "sysMenu:list", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910623L, "system", "sys_file_mgr_sys_file", "system/file/index", null, null, null, false, null, null, "系统文件", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/file", 100, 0, 1, "Y", 1 },
                    { 142307070910621L, "system", "sys_role_mgr_grant_data", null, null, null, null, false, null, null, "字典值详情", 0, "sysDictData:detail", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910620L, "system", "sys_dict_mgr_dict_edit", null, null, null, null, false, null, null, "字典值编辑", 0, "sysDictData:edit", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910619L, "system", "sys_dict_mgr_dict_delete", null, null, null, null, false, null, null, "字典值删除", 0, "sysDictData:delete", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910618L, "system", "sys_dict_mgr_dict_add", null, null, null, null, false, null, null, "字典值增加", 0, "sysDictData:add", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "Icon", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "OpenType", "Permission", "Pid", "Pids", "Remark", "Router", "Sort", "Status", "Type", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070910617L, "system", "sys_dict_mgr_dict_list", null, null, null, null, false, null, null, "字典值列表", 0, "sysDictData:list", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910616L, "system", "sys_dict_mgr_dict_page", null, null, null, null, false, null, null, "字典值查询", 0, "sysDictData:page", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910615L, "system", "sys_dict_mgr_dict_type_change_status", null, null, null, null, false, null, null, "字典类型修改状态", 0, "sysDictType:changeStatus", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910614L, "system", "sys_dict_mgr_dict_type_drop_down", null, null, null, null, false, null, null, "字典类型下拉", 0, "sysDictType:dropDown", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910613L, "system", "sys_dict_mgr_dict_type_detail", null, null, null, null, false, null, null, "字典类型详情", 0, "sysDictType:detail", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910622L, "system", "sys_dict_mgr_dict_change_status", null, null, null, null, false, null, null, "字典值修改状态", 0, "sysDictData:changeStatus", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910814L, "system", "sys_menu_mgr_add", null, null, null, null, false, null, null, "菜单增加", 0, "sysMenu:add", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911506L, "system", "sys_monitor_mgr_online_user_force_exist", null, null, null, null, false, null, null, "在线用户强退", 0, "sysOnlineUser:forceExist", 142307070911504L, "[0],[142307070911501],[142307070911504],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910816L, "system", "sys_menu_mgr_delete", null, null, null, null, false, null, null, "菜单删除", 0, "sysMenu:delete", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911610L, "system", "sys_log_mgr_ex_log_delete", null, null, null, null, false, null, null, "异常日志清空", 0, "sysExLog:delete", 142307070911608L, "[0],[142307070911601],[142307070911608],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911609L, "system", "sys_log_mgr_ex_log_page", null, null, null, null, false, null, null, "异常日志查询", 0, "sysExLog:page", 142307070911608L, "[0],[142307070911601],[142307070911608],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911608L, "system", "sys_log_mgr_ex_log", "system/log/exlog/index", null, null, null, false, null, null, "异常日志", 1, null, 142307070911601L, "[0],[142307070911601],", null, "/exlog", 100, 0, 1, "Y", 1 },
                    { 142307070911607L, "system", "sys_log_mgr_op_log_delete", null, null, null, null, false, null, null, "操作日志清空", 0, "sysOpLog:delete", 142307070911605L, "[0],[142307070911601],[142307070911605],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911606L, "system", "sys_log_mgr_op_log_page", null, null, null, null, false, null, null, "操作日志查询", 0, "sysOpLog:page", 142307070911605L, "[0],[142307070911601],[142307070911605],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911605L, "system", "sys_log_mgr_op_log", "system/log/oplog/index", null, null, null, false, null, null, "操作日志", 1, null, 142307070911601L, "[0],[142307070911601],", null, "/oplog", 100, 0, 1, "Y", 1 },
                    { 142307070911604L, "system", "sys_log_mgr_vis_log_delete", null, null, null, null, false, null, null, "访问日志清空", 0, "sysVisLog:delete", 142307070911602L, "[0],[142307070911601],[142307070911602],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911603L, "system", "sys_log_mgr_vis_log_page", null, null, null, null, false, null, null, "访问日志查询", 0, "sysVisLog:page", 142307070911602L, "[0],[142307070911601],[142307070911602],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911602L, "system", "sys_log_mgr_vis_log", "system/log/vislog/index", null, null, null, false, null, null, "访问日志", 1, null, 142307070911601L, "[0],[142307070911601],", null, "/vislog", 100, 0, 1, "Y", 1 },
                    { 142307070911601L, "system", "sys_log_mgr", "", null, null, "layui-icon layui-icon-tabs", false, null, null, "日志管理", 0, null, 0L, "[0],", null, "/log", 100, 0, 0, "Y", 1 },
                    { 142307070910815L, "system", "sys_menu_mgr_edit", null, null, null, null, false, null, null, "菜单编辑", 0, "sysMenu:edit", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911507L, "system", "sys_monitor_mgr_druid", "system/druid/index", null, null, null, false, null, null, "数据监控", 2, null, 142307070911501L, "[0],[142307070911501],", null, "/druid", 100, 0, 1, "N", 1 },
                    { 142307070911505L, "system", "sys_monitor_mgr_online_user_list", null, null, null, null, false, null, null, "在线用户列表", 0, "sysOnlineUser:list", 142307070911504L, "[0],[142307070911501],[142307070911504],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911504L, "system", "sys_monitor_mgr_online_user", "system/onlineUser/index", null, null, null, false, null, null, "在线用户", 1, null, 142307070911501L, "[0],[142307070911501],", null, "/onlineUser", 100, 0, 1, "Y", 1 },
                    { 142307070911503L, "system", "sys_monitor_mgr_machine_monitor_query", null, null, null, null, false, null, null, "服务监控查询", 0, "sysMachine:query", 142307070911502L, "[0],[142307070911501],[142307070911502],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070911502L, "system", "sys_monitor_mgr_machine_monitor", "system/machine/index", null, null, null, false, null, null, "服务监控", 1, null, 142307070911501L, "[0],[142307070911501],", null, "/machine", 100, 0, 1, "Y", 1 },
                    { 142307070911501L, "system", "sys_monitor_mgr", "", null, null, "layui-icon layui-icon-console", false, null, null, "系统监控", 0, null, 0L, "[0],", null, "/monitor", 100, 0, 0, "Y", 1 },
                    { 142307070910821L, "system", "sys_swagger_mgr", "/swagger/index.html", null, null, null, false, null, null, "接口文档", 2, null, 142307070910811L, "[0],[142307070910811],", null, "/swagger", 100, 0, 1, "Y", 1 },
                    { 142307070910820L, "system", "sys_menu_mgr_change", null, null, null, null, false, null, null, "菜单切换", 0, "sysMenu:change", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910819L, "system", "sys_menu_mgr_tree", null, null, null, null, false, null, null, "菜单树", 0, "sysMenu:tree", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910818L, "system", "sys_menu_mgr_grant_tree", null, null, null, null, false, null, null, "菜单授权树", 0, "sysMenu:treeForGrant", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910817L, "system", "sys_menu_mgr_detail", null, null, null, null, false, null, null, "菜单详情", 0, "sysMenu:detail", 142307070910812L, "[0],[142307070910811],[142307070910812],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910611L, "system", "sys_dict_mgr_dict_type_delete", null, null, null, null, false, null, null, "字典类型删除", 0, "sysDictType:delete", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910610L, "system", "sys_dict_mgr_dict_type_add", null, null, null, null, false, null, null, "字典类型增加", 0, "sysDictType:add", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910600L, "system", "sys_role_mgr_delete", null, null, null, null, false, null, null, "角色删除", 0, "sysRole:delete", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910608L, "system", "sys_dict_mgr_dict_type_page", null, null, null, null, false, null, null, "字典类型查询", 0, "sysDictType:page", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910581L, "system", "sys_org_mgr", "system/org/index", null, null, null, false, null, null, "机构管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/org", 100, 0, 1, "Y", 1 },
                    { 142307070910609L, "system", "sys_dict_mgr_dict_type_list", null, null, null, null, false, null, null, "字典类型列表", 0, "sysDictType:list", 142307070910607L, "[0],[142307070910563],[142307070910607],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910579L, "system", "sys_user_mgr_update_avatar", null, null, null, null, false, null, null, "用户修改头像", 0, "sysUser:updateAvatar", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910578L, "system", "sys_user_mgr_change_status", null, null, null, null, false, null, null, "用户修改状态", 0, "sysUser:changeStatus", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910577L, "system", "sys_user_mgr_update_pwd", null, null, null, null, false, null, null, "用户修改密码", 0, "sysUser:updatePwd", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910576L, "system", "sys_user_mgr_update_info", null, null, null, null, false, null, null, "用户更新信息", 0, "sysUser:updateInfo", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910575L, "system", "sys_user_mgr_own_data", null, null, null, null, false, null, null, "用户拥有数据", 0, "sysUser:ownData", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "Icon", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "OpenType", "Permission", "Pid", "Pids", "Remark", "Router", "Sort", "Status", "Type", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070910574L, "system", "sys_user_mgr_grant_data", null, null, null, null, false, null, null, "用户授权数据", 0, "sysUser:grantData", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910573L, "system", "sys_user_mgr_own_role", null, null, null, null, false, null, null, "用户拥有角色", 0, "sysUser:ownRole", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910572L, "system", "sys_user_mgr_grant_role", null, null, null, null, false, null, null, "用户授权角色", 0, "sysUser:grantRole", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910582L, "system", "sys_org_mgr_page", null, null, null, null, false, null, null, "机构查询", 0, "sysOrg:page", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910571L, "system", "sys_user_mgr_selector", null, null, null, null, false, null, null, "用户选择器", 0, "sysUser:selector", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910569L, "system", "sys_user_mgr_detail", null, null, null, null, false, null, null, "用户详情", 0, "sysUser:detail", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910568L, "system", "sys_user_mgr_delete", null, null, null, null, false, null, null, "用户删除", 0, "sysUser:delete", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910567L, "system", "sys_user_mgr_add", null, null, null, null, false, null, null, "用户增加", 0, "sysUser:add", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910566L, "system", "sys_user_mgr_edit", null, null, null, null, false, null, null, "用户编辑", 0, "sysUser:edit", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910565L, "system", "sys_user_mgr_page", null, null, null, null, false, null, null, "用户查询", 0, "sysUser:page", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910564L, "system", "sys_user_mgr", "system/user/index", null, null, null, false, null, null, "用户管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/mgr_user", 100, 0, 1, "Y", 1 },
                    { 142307070910563L, "system", "sys_mgr", "", null, null, "layui-icon layui-icon-set", false, null, null, "系统管理", 0, null, 0L, "[0],", null, "/sys", 100, 0, 0, "Y", 1 },
                    { 142307070910562L, "system", "system_index_workplace", "system/dashboard/Workplace", null, null, null, false, null, null, "工作台", 0, null, 142307070910560L, "[0],[142307070910560],", null, "workplace", 100, 0, 1, "Y", 1 },
                    { 142307070910561L, "system", "system_index_dashboard", "system/dashboard/Analysis", null, null, null, false, null, null, "分析页", 0, null, 142307070910560L, "[0],[142307070910560],", null, "analysis", 100, 0, 1, "Y", 1 },
                    { 142307070910560L, "system", "system_index", "", null, null, "layui-icon layui-icon-chart-screen", false, null, null, "主控面板", 0, null, 0L, "[0],", null, "/", 1, 0, 0, "Y", 1 },
                    { 142307070910570L, "system", "sys_user_mgr_export", null, null, null, null, false, null, null, "用户导出", 0, "sysUser:export", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910583L, "system", "sys_org_mgr_list", null, null, null, null, false, null, null, "机构列表", 0, "sysOrg:list", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910580L, "system", "sys_user_mgr_reset_pwd", null, null, null, null, false, null, null, "用户重置密码", 0, "sysUser:resetPwd", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910585L, "system", "sys_org_mgr_edit", null, null, null, null, false, null, null, "机构编辑", 0, "sysOrg:edit", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910607L, "system", "sys_dict_mgr", "system/dict/index", null, null, null, false, null, null, "字典管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/dict", 100, 0, 1, "Y", 1 },
                    { 142307070910606L, "system", "sys_role_mgr_own_data", null, null, null, null, false, null, null, "角色拥有数据", 0, "sysRole:ownData", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910605L, "system", "sys_role_mgr_grant_data", null, null, null, null, false, null, null, "角色授权数据", 0, "sysRole:grantData", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910604L, "system", "sys_role_mgr_own_menu", null, null, null, null, false, null, null, "角色拥有菜单", 0, "sysRole:ownMenu", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910603L, "system", "sys_role_mgr_grant_menu", null, null, null, null, false, null, null, "角色授权菜单", 0, "sysRole:grantMenu", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910602L, "system", "sys_role_mgr_drop_down", null, null, null, null, false, null, null, "角色下拉", 0, "sysRole:dropDown", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910601L, "system", "sys_role_mgr_detail", null, null, null, null, false, null, null, "角色详情", 0, "sysRole:detail", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910584L, "system", "sys_org_mgr_add", null, null, null, null, false, null, null, "机构增加", 0, "sysOrg:add", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910598L, "system", "sys_role_mgr_add", null, null, null, null, false, null, null, "角色增加", 0, "sysRole:add", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910597L, "system", "sys_role_mgr_page", null, null, null, null, false, null, null, "角色查询", 0, "sysRole:page", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910599L, "system", "sys_role_mgr_edit", null, null, null, null, false, null, null, "角色编辑", 0, "sysRole:edit", 142307070910596L, "[0],[142307070910563],[142307070910596],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910595L, "system", "sys_pos_mgr_detail", null, null, null, null, false, null, null, "职位详情", 0, "sysPos:detail", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910586L, "system", "sys_org_mgr_delete", null, null, null, null, false, null, null, "机构删除", 0, "sysOrg:delete", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910587L, "system", "sys_org_mgr_detail", null, null, null, null, false, null, null, "机构详情", 0, "sysOrg:detail", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910596L, "system", "sys_role_mgr", "system/role/index", null, null, null, false, null, null, "角色管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/role", 100, 0, 1, "Y", 1 },
                    { 142307070910589L, "system", "sys_pos_mgr", "system/pos/index", null, null, null, false, null, null, "职位管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, "/pos", 100, 0, 1, "Y", 1 },
                    { 142307070910590L, "system", "sys_pos_mgr_page", null, null, null, null, false, null, null, "职位查询", 0, "sysPos:page", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910588L, "system", "sys_org_mgr_tree", null, null, null, null, false, null, null, "机构树", 0, "sysOrg:tree", 142307070910581L, "[0],[142307070910563],[142307070910581],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910592L, "system", "sys_pos_mgr_add", null, null, null, null, false, null, null, "职位增加", 0, "sysPos:add", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910593L, "system", "sys_pos_mgr_edit", null, null, null, null, false, null, null, "职位编辑", 0, "sysPos:edit", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910594L, "system", "sys_pos_mgr_delete", null, null, null, null, false, null, null, "职位删除", 0, "sysPos:delete", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 },
                    { 142307070910591L, "system", "sys_pos_mgr_list", null, null, null, null, false, null, null, "职位列表", 0, "sysPos:list", 142307070910589L, "[0],[142307070910563],[142307070910589],", null, null, 100, 0, 2, "Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "sys_org",
                columns: new[] { "Id", "Code", "Contacts", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Pid", "Pids", "Remark", "Sort", "Status", "Tel" },
                values: new object[] { 142307070910539L, "amjt", null, null, null, false, null, null, "艾米集团", 0L, "[0],", "华夏集团", 100, 0, null });

            migrationBuilder.InsertData(
                table: "sys_org",
                columns: new[] { "Id", "Code", "Contacts", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Pid", "Pids", "Remark", "Sort", "Status", "Tel" },
                values: new object[] { 142307070910540L, "amjt_bj", null, null, null, false, null, null, "ws公司", 142307070910539L, "[0],[142307070910539],", "ws公司", 100, 0, null });

            migrationBuilder.InsertData(
                table: "sys_pos",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Remark", "Sort", "Status" },
                values: new object[,]
                {
                    { 142307070910550L, "gzry", null, null, false, null, null, "开发项目组", "工作人员", 103, 0 },
                    { 142307070910547L, "zjl", null, null, false, null, null, "总经理", "总经理", 100, 0 },
                    { 142307070910548L, "fzjl", null, null, false, null, null, "副总经理", "副总经理", 101, 0 },
                    { 142307070910549L, "bmjl", null, null, false, null, null, "部门经理", "部门经理", 102, 0 }
                });

            migrationBuilder.InsertData(
                table: "sys_role",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "DataScopeType", "IsDeleted", "ModifyTime", "ModifyUserId", "Name", "Remark", "Sort", "Status" },
                values: new object[] { 142307070910554L, "sys_manager_role", null, null, 1, false, null, null, "系统管理员", "系统管理员", 100, 0 });

            migrationBuilder.InsertData(
                table: "sys_user",
                columns: new[] { "Id", "Account", "AdminType", "Avatar", "Birthday", "CreatedTime", "CreatedUserId", "Email", "IsDeleted", "LastLoginIp", "LastLoginTime", "ModifyTime", "ModifyUserId", "Name", "NickName", "Password", "Phone", "Sex", "Status", "Tel" },
                values: new object[,]
                {
                    { 142307070910551L, "superAdmin", 1, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "superAdmin", null, "e10adc3949ba59abbe56e057f20f883e", "15669067312", 1, 0, null },
                    { 142307070910552L, "admin", 2, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin", null, "e10adc3949ba59abbe56e057f20f883e", "15669067312", 1, 0, null }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_data",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Remark", "Sort", "Status", "TypeId", "Value" },
                values: new object[,]
                {
                    { 142307070902384L, "0", null, null, false, null, null, "正常", 100, 0, 142307070906483L, "正常" },
                    { 142307070922830L, "input", null, null, false, null, null, "输入框", 100, 0, 142307070922827L, "输入框" },
                    { 142307070906482L, "4", null, null, false, null, null, "DELETE", 100, 0, 142307070910538L, "DELETE" },
                    { 142307070906481L, "3", null, null, false, null, null, "PUT", 100, 0, 142307070910538L, "PUT" },
                    { 142307070906480L, "2", null, null, false, null, null, "POST", 100, 0, 142307070910538L, "POST" },
                    { 142307070906479L, "1", null, null, false, null, null, "GET", 100, 0, 142307070910538L, "GET" },
                    { 142307070906478L, "2", null, null, false, null, null, "生成到本项目", 100, 0, 142307070910537L, "生成到本项目" },
                    { 142307070906477L, "1", null, null, false, null, null, "下载压缩包", 100, 0, 142307070910537L, "下载压缩包" },
                    { 142307070906476L, "false", null, null, false, null, null, "否", 100, 0, 142307070910536L, "否" },
                    { 142307070906475L, "true", null, null, false, null, null, "是", 100, 0, 142307070910536L, "是" },
                    { 142307070922831L, "datepicker", null, null, false, null, null, "时间选择", 100, 0, 142307070922827L, "时间选择" },
                    { 142307070906474L, "3", null, null, false, null, null, "删除", 100, 0, 142307070910535L, "删除" },
                    { 142307070906472L, "1", null, null, false, null, null, "发布", 100, 0, 142307070910535L, "发布" },
                    { 142307070906471L, "0", null, null, false, null, null, "草稿", 100, 0, 142307070910535L, "草稿" },
                    { 142307070906470L, "2", null, null, false, null, null, "公告", 100, 0, 142307070910534L, "公告" },
                    { 142307070906469L, "1", null, null, false, null, null, "通知", 100, 0, 142307070910534L, "通知" },
                    { 142307070906468L, "2", null, null, false, null, null, "停止", 100, 0, 142307070910533L, "停止" },
                    { 142307070906467L, "1", null, null, false, null, null, "运行", 100, 0, 142307070910533L, "运行" },
                    { 142307070906466L, "4", null, null, false, null, null, "本地", 100, 0, 142307070906495L, "本地" },
                    { 142307070906465L, "3", null, null, false, null, null, "minio", 100, 0, 142307070906495L, "minio" },
                    { 142307070906463L, "1", null, null, false, null, null, "阿里云", 100, 0, 142307070906495L, "阿里云" },
                    { 142307070906473L, "2", null, null, false, null, null, "撤回", 100, 0, 142307070910535L, "撤回" },
                    { 142307070922832L, "select", null, null, false, null, null, "下拉框", 100, 0, 142307070922827L, "下拉框" },
                    { 142307070922833L, "radio", null, null, false, null, null, "单选框", 100, 0, 142307070922827L, "单选框" },
                    { 142307070922834L, "switch", null, null, false, null, null, "开关", 100, 0, 142307070922827L, "开关" },
                    { 142307070922864L, "DateTimeOffset", null, null, false, null, null, "DateTimeOffset", 100, 0, 142307070922829L, "DateTimeOffset" },
                    { 142307070922863L, "Guid", null, null, false, null, null, "Guid", 100, 0, 142307070922829L, "Guid" },
                    { 142307070922862L, "decimal", null, null, false, null, null, "decimal", 100, 0, 142307070922829L, "decimal" },
                    { 142307070922861L, "float", null, null, false, null, null, "float", 100, 0, 142307070922829L, "float" },
                    { 142307070922848L, "DateTime", null, null, false, null, null, "DateTime", 100, 0, 142307070922829L, "DateTime" },
                    { 142307070922852L, "double", null, null, false, null, null, "double", 100, 0, 142307070922829L, "double" },
                    { 142307070922850L, "bool", null, null, false, null, null, "bool", 100, 0, 142307070922829L, "bool" },
                    { 142307070922847L, "string", null, null, false, null, null, "string", 100, 0, 142307070922829L, "string" },
                    { 142307070922846L, "long", null, null, false, null, null, "long", 100, 0, 142307070922829L, "long" },
                    { 142307070922851L, "int", null, null, false, null, null, "int", 100, 0, 142307070922829L, "int" },
                    { 142307070922845L, "isNotNull", null, null, false, null, null, "不为空", 8, 0, 142307070922828L, "不为空" },
                    { 142307070922844L, "<=", null, null, false, null, null, "小于等于", 7, 0, 142307070922828L, "小于等于" },
                    { 142307070922843L, ">=", null, null, false, null, null, "大于等于", 6, 0, 142307070922828L, "大于等于" },
                    { 142307070922842L, "!=", null, null, false, null, null, "不等于", 5, 0, 142307070922828L, "不等于" },
                    { 142307070922841L, "<", null, null, false, null, null, "小于", 4, 0, 142307070922828L, "小于" },
                    { 142307070922840L, ">", null, null, false, null, null, "大于", 3, 0, 142307070922828L, "大于" },
                    { 142307070922839L, "like", null, null, false, null, null, "模糊", 2, 0, 142307070922828L, "模糊" }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_data",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Remark", "Sort", "Status", "TypeId", "Value" },
                values: new object[,]
                {
                    { 142307070922838L, "==", null, null, false, null, null, "等于", 1, 0, 142307070922828L, "等于" },
                    { 142307070922837L, "textarea", null, null, false, null, null, "文本域", 100, 0, 142307070922827L, "文本域" },
                    { 142307070922836L, "inputnumber", null, null, false, null, null, "数字输入框", 100, 0, 142307070922827L, "数字输入框" },
                    { 142307070922835L, "checkbox", null, null, false, null, null, "多选框", 100, 0, 142307070922827L, "多选框" },
                    { 142307070906462L, "13", null, null, false, null, null, "修改状态", 100, 0, 142307070906494L, "修改状态" },
                    { 142307070906461L, "12", null, null, false, null, null, "清空", 100, 0, 142307070906494L, "清空" },
                    { 142307070906464L, "2", null, null, false, null, null, "腾讯云", 100, 0, 142307070906495L, "腾讯云" },
                    { 142307070906459L, "10", null, null, false, null, null, "授权", 100, 0, 142307070906494L, "授权" },
                    { 142307070906460L, "11", null, null, false, null, null, "强退", 100, 0, 142307070906494L, "强退" },
                    { 142307070902395L, "1", null, null, false, null, null, "发送成功", 100, 0, 142307070906489L, "发送成功" },
                    { 142307070902394L, "0", null, null, false, null, null, "未发送", 100, 0, 142307070906489L, "未发送" },
                    { 142307070902393L, "2", null, null, false, null, null, "按钮", 100, 0, 142307070906488L, "按钮" },
                    { 142307070902392L, "1", null, null, false, null, null, "菜单", 100, 0, 142307070906488L, "菜单" },
                    { 142307070902391L, "0", null, null, false, null, null, "目录", 100, 0, 142307070906488L, "目录" },
                    { 142307070902390L, "2", null, null, false, null, null, "登出", 100, 0, 142307070906487L, "登出" },
                    { 142307070902389L, "1", null, null, false, null, null, "登录", 100, 0, 142307070906487L, "登录" },
                    { 142307070902388L, "Y", null, null, false, null, null, "是", 100, 0, 142307070906486L, "是" },
                    { 142307070902387L, "N", null, null, false, null, null, "否", 100, 0, 142307070906486L, "否" },
                    { 142307070902383L, "OAUTH", null, null, false, null, null, "Oauth配置", 100, 0, 142307070906485L, "Oauth配置" },
                    { 142307070902382L, "FILE_PATH", null, null, false, null, null, "文件上传路径", 100, 0, 142307070906485L, "文件上传路径" },
                    { 142307070902381L, "EMAIL", null, null, false, null, null, "邮件配置", 100, 0, 142307070906485L, "邮件配置" },
                    { 142307070902380L, "TENCENT_SMS", null, null, false, null, null, "腾讯云短信", 100, 0, 142307070906485L, "腾讯云短信" },
                    { 142307070902379L, "ALIYUN_SMS", null, null, false, null, null, "阿里云短信配置", 100, 0, 142307070906485L, "阿里云短信" },
                    { 142307070902378L, "DEFAULT", null, null, false, null, null, "默认常量，都以XIAONUO_开头的", 100, 0, 142307070906485L, "默认常量" },
                    { 142307070902377L, "3", null, null, false, null, null, "未知性别", 100, 0, 142307070906484L, "未知" },
                    { 142307070902376L, "2", null, null, false, null, null, "女性", 100, 0, 142307070906484L, "女" },
                    { 142307070902375L, "1", null, null, false, null, null, "男性", 100, 0, 142307070906484L, "男" },
                    { 142307070902386L, "2", null, null, false, null, null, "删除", 100, 0, 142307070906483L, "删除" },
                    { 142307070902385L, "1", null, null, false, null, null, "停用", 100, 0, 142307070906483L, "停用" },
                    { 142307070902397L, "3", null, null, false, null, null, "失效", 100, 0, 142307070906489L, "失效" },
                    { 142307070902398L, "0", null, null, false, null, null, "无", 100, 0, 142307070906490L, "无" },
                    { 142307070902396L, "2", null, null, false, null, null, "发送失败", 100, 0, 142307070906489L, "发送失败" },
                    { 142307070906437L, "2", null, null, false, null, null, "内链", 100, 0, 142307070906490L, "内链" },
                    { 142307070906458L, "9", null, null, false, null, null, "导出", 100, 0, 142307070906494L, "导出" },
                    { 142307070906457L, "8", null, null, false, null, null, "导入", 100, 0, 142307070906494L, "导入" },
                    { 142307070906456L, "7", null, null, false, null, null, "树", 100, 0, 142307070906494L, "树" },
                    { 142307070906455L, "6", null, null, false, null, null, "详情", 100, 0, 142307070906494L, "详情" },
                    { 142307070906454L, "5", null, null, false, null, null, "查询", 100, 0, 142307070906494L, "查询" },
                    { 142307070906453L, "4", null, null, false, null, null, "更新", 100, 0, 142307070906494L, "更新" },
                    { 142307070902399L, "1", null, null, false, null, null, "组件", 100, 0, 142307070906490L, "组件" },
                    { 142307070906451L, "2", null, null, false, null, null, "删除", 100, 0, 142307070906494L, "删除" },
                    { 142307070906450L, "1", null, null, false, null, null, "增加", 100, 0, 142307070906494L, "增加" }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_data",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "IsDeleted", "ModifyTime", "ModifyUserId", "Remark", "Sort", "Status", "TypeId", "Value" },
                values: new object[,]
                {
                    { 142307070906449L, "0", null, null, false, null, null, "其它", 100, 0, 142307070906494L, "其它" },
                    { 142307070906452L, "3", null, null, false, null, null, "编辑", 100, 0, 142307070906494L, "编辑" },
                    { 142307070906447L, "2", null, null, false, null, null, "pc", 100, 0, 142307070906493L, "pc" },
                    { 142307070906438L, "3", null, null, false, null, null, "外链", 100, 0, 142307070906490L, "外链" },
                    { 142307070906448L, "3", null, null, false, null, null, "其他", 100, 0, 142307070906493L, "其他" },
                    { 142307070906440L, "2", null, null, false, null, null, "业务权重", 100, 0, 142307070906491L, "业务权重" },
                    { 142307070906441L, "1", null, null, false, null, null, "全部数据", 100, 0, 142307070906492L, "全部数据" },
                    { 142307070906439L, "1", null, null, false, null, null, "系统权重", 100, 0, 142307070906491L, "系统权重" },
                    { 142307070906443L, "3", null, null, false, null, null, "本部门数据", 100, 0, 142307070906492L, "本部门数据" },
                    { 142307070906444L, "4", null, null, false, null, null, "仅本人数据", 100, 0, 142307070906492L, "仅本人数据" },
                    { 142307070906445L, "5", null, null, false, null, null, "自定义数据", 100, 0, 142307070906492L, "自定义数据" },
                    { 142307070906446L, "1", null, null, false, null, null, "app", 100, 0, 142307070906493L, "app" },
                    { 142307070906442L, "2", null, null, false, null, null, "本部门及以下数据", 100, 0, 142307070906492L, "本部门及以下数据" }
                });

            migrationBuilder.InsertData(
                table: "sys_emp_pos",
                columns: new[] { "SysEmpId", "SysPosId" },
                values: new object[,]
                {
                    { 142307070910551L, 142307070910548L },
                    { 142307070910552L, 142307070910549L },
                    { 142307070910551L, 142307070910550L }
                });

            migrationBuilder.InsertData(
                table: "sys_role_menu",
                columns: new[] { "SysMenuId", "SysRoleId" },
                values: new object[,]
                {
                    { 142307070910560L, 142307070910554L },
                    { 142307070910561L, 142307070910554L },
                    { 142307070910562L, 142307070910554L }
                });

            migrationBuilder.InsertData(
                table: "sys_user_data_scope",
                columns: new[] { "SysOrgId", "SysUserId" },
                values: new object[] { 142307070910539L, 142307070910552L });

            migrationBuilder.InsertData(
                table: "sys_user_role",
                columns: new[] { "SysRoleId", "SysUserId" },
                values: new object[] { 142307070910554L, 142307070910552L });

            migrationBuilder.CreateIndex(
                name: "IX_sys_dict_data_TypeId",
                table: "sys_dict_data",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_ext_org_pos_SysOrgId",
                table: "sys_emp_ext_org_pos",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_ext_org_pos_SysPosId",
                table: "sys_emp_ext_org_pos",
                column: "SysPosId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_pos_SysPosId",
                table: "sys_emp_pos",
                column: "SysPosId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_data_scope_SysOrgId",
                table: "sys_role_data_scope",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_menu_SysMenuId",
                table: "sys_role_menu",
                column: "SysMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_data_scope_SysOrgId",
                table: "sys_user_data_scope",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_role_SysRoleId",
                table: "sys_user_role",
                column: "SysRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_app");

            migrationBuilder.DropTable(
                name: "sys_dict_data");

            migrationBuilder.DropTable(
                name: "sys_emp_ext_org_pos");

            migrationBuilder.DropTable(
                name: "sys_emp_pos");

            migrationBuilder.DropTable(
                name: "sys_file");

            migrationBuilder.DropTable(
                name: "sys_log_audit");

            migrationBuilder.DropTable(
                name: "sys_log_ex");

            migrationBuilder.DropTable(
                name: "sys_log_op");

            migrationBuilder.DropTable(
                name: "sys_log_vis");

            migrationBuilder.DropTable(
                name: "sys_oauth_user");

            migrationBuilder.DropTable(
                name: "sys_role_data_scope");

            migrationBuilder.DropTable(
                name: "sys_role_menu");

            migrationBuilder.DropTable(
                name: "sys_user_data_scope");

            migrationBuilder.DropTable(
                name: "sys_user_role");

            migrationBuilder.DropTable(
                name: "sys_dict_type");

            migrationBuilder.DropTable(
                name: "sys_emp");

            migrationBuilder.DropTable(
                name: "sys_pos");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_org");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");
        }
    }
}
