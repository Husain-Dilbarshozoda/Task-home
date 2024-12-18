create table Users
(
    UserId serial primary key,
    FullName varchar(150),
    Email varchar(150),
    Phone varchar(20),
    City varchar(100),
    CreatedAt timestamp
);


create table Skills
(
    SkillId serial primary key,
    Title varchar(150),
    Description text,
    CreatedAt timestamp,
    UserId int references Users(UserId)
);


create table Requests
(
    RequestId serial primary key,
    Status varchar(20),
    CreatedAt timestamp,
    UpdatedAt timestamp,
    FromUserId int references Users(UserId),
    ToUserId int references Users(UserId),
    RequestedSkillId int references Skills(SkillId),
    OfferedSkillId int references Skills(SkillId)
);

