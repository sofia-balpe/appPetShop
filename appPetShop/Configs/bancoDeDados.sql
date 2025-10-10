/*
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
*/
