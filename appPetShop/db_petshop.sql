create database pds_app_web_petshop;
use pds_app_web_petshop;


create database pds_app_web_petshop;
use pds_app_web_petshop;

create table Cliente (
    id_cli int primary key auto_increment,
    nome_cli varchar(200),
    cpf_cli varchar(14),
    cep_cli varchar(20),
    rua_cli varchar (200),
    bairro_cli varchar (200),
    numero_cli Varchar(200),
    complemento_cli varchar (300),
    telefone_cli varchar(30),
    email_cli varchar (100),
    dataNascimento_cli varchar(100)
);

Create table Produto(
id_pro int primary key auto_increment,
nome_pro varchar(200),
descricao_pro varchar(300),
quantidade_pro double,
valor_unitario_pro double);

insert into Produto values (null, 'top', 'top', 5, 5);



Create table Pet(
id_pet int primary key auto_increment,
nome_pet varchar(200),
especie_pet varchar(200),
raca_pet varchar(200),
data_nascimento_pet varchar(100),
idade_pet double,
porte_pet varchar(200),
peso_pet double,
id_cli_fk int not null,
id_esp_fk int not null
);
alter table Pet add foreign Key (id_cli_fk) references cliente(id_cli);
alter table Pet add foreign Key (id_esp_fk) references especie(id_esp);
drop table pet;

create table Raca(
id_raca int primary key auto_increment,
nome_raca varchar(200),
porte_raca varchar(200),
expectativa_de_vida varchar(300),
Observacoes_raca varchar(300)
);

Create table Especie(
id_esp int primary key auto_increment,
nome_esp varchar (200),
nomeCient_esp varchar (200),
alimen_esp varchar (200),
habitat_esp varchar (200)
);
insert into especie values (null, 'teste', 'teste', 'teste', 'teste');




