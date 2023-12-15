
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2023 01:12:30
-- Generated from EDMX file: C:\Users\Josef\source\repos\EDUNICA\EDUNICA\Models\DiagramaEDUNICA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EDUNICABD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Estudiantes'
CREATE TABLE [dbo].[Estudiantes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreEstudiante] nvarchar(max)  NOT NULL,
    [Edad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Grados'
CREATE TABLE [dbo].[Grados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreGrado] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Cursos'
CREATE TABLE [dbo].[Cursos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCurso] nvarchar(150)  NOT NULL,
    [Presupuesto] NUMERIC(12,0)  NOT NULL,
    [CategoriaId] int  NOT NULL,
    [GradoId] int  NOT NULL,
    [MaestroId] int  NOT NULL,
    [ColaboracionId] int  NOT NULL
);
GO

-- Creating table 'Progresos'
CREATE TABLE [dbo].[Progresos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] int  NOT NULL
);
GO

-- Creating table 'Colaboraciones'
CREATE TABLE [dbo].[Colaboraciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TipoColaboracion] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Maestros'
CREATE TABLE [dbo].[Maestros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreMaestro] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCategoria] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'InteresesCategorias'
CREATE TABLE [dbo].[InteresesCategorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EstudianteId] int  NOT NULL,
    [CategoriaId] int  NOT NULL
);
GO

-- Creating table 'Lecciones'
CREATE TABLE [dbo].[Lecciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreLeccion] nvarchar (200)  NOT NULL,
    [Descripcion] nvarchar(500)  NOT NULL,
    [Completado] bit default 0,
    [CursoId] int  NOT NULL,
    [ProgresoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grados'
ALTER TABLE [dbo].[Grados]
ADD CONSTRAINT [PK_Grados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [PK_Cursos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Progresos'
ALTER TABLE [dbo].[Progresos]
ADD CONSTRAINT [PK_Progresos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Colaboraciones'
ALTER TABLE [dbo].[Colaboraciones]
ADD CONSTRAINT [PK_Colaboraciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Maestros'
ALTER TABLE [dbo].[Maestros]
ADD CONSTRAINT [PK_Maestros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InteresesCategorias'
ALTER TABLE [dbo].[InteresesCategorias]
ADD CONSTRAINT [PK_InteresesCategorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lecciones'
ALTER TABLE [dbo].[Lecciones]
ADD CONSTRAINT [PK_Lecciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EstudianteId] in table 'InteresesCategorias'
ALTER TABLE [dbo].[InteresesCategorias]
ADD CONSTRAINT [FK_EstudianteInteresesCategoria]
    FOREIGN KEY ([EstudianteId])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteInteresesCategoria'
CREATE INDEX [IX_FK_EstudianteInteresesCategoria]
ON [dbo].[InteresesCategorias]
    ([EstudianteId]);
GO

-- Creating foreign key on [CategoriaId] in table 'InteresesCategorias'
ALTER TABLE [dbo].[InteresesCategorias]
ADD CONSTRAINT [FK_CategoriaInteresesCategoria]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaInteresesCategoria'
CREATE INDEX [IX_FK_CategoriaInteresesCategoria]
ON [dbo].[InteresesCategorias]
    ([CategoriaId]);
GO

-- Creating foreign key on [CategoriaId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_CategoriaCurso]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaCurso'
CREATE INDEX [IX_FK_CategoriaCurso]
ON [dbo].[Cursos]
    ([CategoriaId]);
GO

-- Creating foreign key on [CursoId] in table 'Lecciones'
ALTER TABLE [dbo].[Lecciones]
ADD CONSTRAINT [FK_CursoLeccion]
    FOREIGN KEY ([CursoId])
    REFERENCES [dbo].[Cursos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoLeccion'
CREATE INDEX [IX_FK_CursoLeccion]
ON [dbo].[Lecciones]
    ([CursoId]);
GO

-- Creating foreign key on [ProgresoId] in table 'Lecciones'
ALTER TABLE [dbo].[Lecciones]
ADD CONSTRAINT [FK_ProgresoLeccion]
    FOREIGN KEY ([ProgresoId])
    REFERENCES [dbo].[Progresos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgresoLeccion'
CREATE INDEX [IX_FK_ProgresoLeccion]
ON [dbo].[Lecciones]
    ([ProgresoId]);
GO

-- Creating foreign key on [GradoId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_GradoCurso]
    FOREIGN KEY ([GradoId])
    REFERENCES [dbo].[Grados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradoCurso'
CREATE INDEX [IX_FK_GradoCurso]
ON [dbo].[Cursos]
    ([GradoId]);
GO

-- Creating foreign key on [MaestroId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_MaestroCurso]
    FOREIGN KEY ([MaestroId])
    REFERENCES [dbo].[Maestros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaestroCurso'
CREATE INDEX [IX_FK_MaestroCurso]
ON [dbo].[Cursos]
    ([MaestroId]);
GO

-- Creating foreign key on [ColaboracionId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_ColaboracionCurso]
    FOREIGN KEY ([ColaboracionId])
    REFERENCES [dbo].[Colaboraciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColaboracionCurso'
CREATE INDEX [IX_FK_ColaboracionCurso]
ON [dbo].[Cursos]
    ([ColaboracionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------