﻿CREATE TABLE Centros
(
IdCentro int PRIMARY key not null,
NombreCentro VARCHAR(255) not null,
Direccion VARCHAR(255),
)

CREATE TABLE Areas
(
IdArea int not null PRIMARY key,
NombreArea VARCHAR(255) not null,
)

CREATE TABLE AreasPorCentro
(
IdAreasPorCentro int not null PRIMARY key,
IdArea int FOREIGN KEY REFERENCES Areas(IdArea) not null,
IdCentro int FOREIGN KEY REFERENCES Centros(IdCentro) not null

)

CREATE TABLE Cursos
(
IdCurso int not null PRIMARY key,
NombreCurso VARCHAR(255) not null,
IdArea int FOREIGN KEY REFERENCES Areas(IdArea) not null,
)

create table Modulos
(
IdModulo int not null primary key,
NombreModulo VARCHAR(255) not null,
)

create table ModulosPorCurso
(
IdModuloPorCurso int not null PRIMARY key,
IdModulo int FOREIGN KEY REFERENCES Modulos(IdModulo) not null,
IdCurso int FOREIGN KEY REFERENCES Cursos(IdCurso) not null
)

create table Preguntas
(
IdPregunta int not null Primary key,
IdModulo int FOREIGN KEY REFERENCES Modulos(IdModulo) not null,
Descripcion VARCHAR(255)
)

create table Respuestas
(
IdRespuesta int not null primary key,
IdPregunta int FOREIGN key REFERENCES Preguntas(IdPregunta),
Descripcion VARCHAR(255)
)

create table Pruebas
(
IdPrueba int not null primary key,
IdModulo int FOREIGN KEY REFERENCES Modulos(IdModulo) not null,
)

create table PreguntasPorPrueba
(
IdPreguntasPorPrueba int not null primary key,
IdPregunta int FOREIGN KEY REFERENCES Preguntas(IdPregunta) not null,
IdPrueba int FOREIGN KEY REFERENCES Pruebas(IdPrueba) not null,
)


create table Usuarios
(
IdUsuario int not null primary key,
Nombre VARCHAR(255),
Apellido VARCHAR(255),
FechaNacimiento date,
IdTipoUsuario int FOREIGN key REFERENCES TipoUsuario(IdTipoUsuario),
IdAspNetUser NVARCHAR (128) FOREIGN key REFERENCES AspNetUsers(Id),
)

create table TipoUsuario
(
IdTipoUsuario int not null primary key,
Descripcion VARCHAR(255),
)

create table InstructorPorCurso
(
IdInstructorPorCurso int not null primary key,
IdUsuario int FOREIGN key REFERENCES Usuarios(IdUsuario),
IdCurso int FOREIGN KEY REFERENCES Cursos(IdCurso) not null
)

create table AlumnoPorCurso
(
IdAlumnoPorCurso int not null primary key,
IdUsuario int FOREIGN key REFERENCES Usuarios(IdUsuario),
IdCurso int FOREIGN KEY REFERENCES Cursos(IdCurso) not null
)


