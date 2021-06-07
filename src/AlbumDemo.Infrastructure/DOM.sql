create table if not exists album (
    id integer primary key autoincrement ,
    name text not null ,
    enabled boolean default true ,
    created date default current_timestamp,
    created_by text not null ,
    last_modified date null ,
    last_modified_by text null
);

create table if not exists photo (
    id integer primary key autoincrement ,
    name text not null ,
    album_id integer not null,
    enabled boolean default true ,
    created date default current_timestamp,
    created_by text not null ,
    last_modified date null ,
    last_modified_by text null,
    foreign key (album_id) references album (id)
);

create table if not exists comment (
    id integer primary key autoincrement ,
    content text not null ,
    photo_id integer not null,
    enabled boolean default true ,
    created date default current_timestamp,
    created_by text not null ,
    last_modified date null ,
    last_modified_by text null,
    foreign key (photo_id) references photo (id)
);

insert into album(id, name, created_by) values (1, 'ALBUM DEMO 1', 'DEMO');
insert into album(id, name, created_by) values (2, 'ALBUM DEMO 2', 'DEMO');

insert into photo(id, name, album_id, created_by) values (1, 'PHOTO DEMO 1', 1, 'DEMO');
insert into photo(id, name, album_id, created_by) values (2, 'PHOTO DEMO 2', 1, 'DEMO');

insert into comment(id, content, photo_id, created_by) values (1, 'CONTENT DEMO 1 PHOTO 1', 1, 'DEMO');
insert into comment(id, content, photo_id, created_by) values (2, 'CONTENT DEMO 2 PHOTO 1', 1, 'DEMO');
insert into comment(id, content, photo_id, created_by) values (3, 'CONTENT DEMO 3 PHOTO 1', 1, 'DEMO');
insert into comment(id, content, photo_id, created_by) values (4, 'CONTENT DEMO 4 PHOTO 2', 2, 'DEMO');