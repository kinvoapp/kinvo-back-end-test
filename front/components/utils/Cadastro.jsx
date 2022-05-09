import React,{useState } from 'react';
import { Form, Col, Row, Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/cadastro.css"


export const dateMask = (value) => {
  return value
    .replace(/\D/g, "")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{4})\d+?$/, "$1");
};
export const cpfMask = (value) => {
  return value
    .replace(/\D/g, "")
    .replace(/(\d{3})(\d)/, "$1.$2")
    .replace(/(\d{3})(\d)/, "$1.$2")
    .replace(/(\d{3})(\d{1,2})/, "$1-$2")
    .replace(/(-\d{2})\d+?$/, "$1");
};

 const Cadastro = (props) => {
  const [nome, setNome] = useState("");
  const [cpf, setCPF] = useState("");
  const [dtNasc, setDtNasc] = useState("");
 
  function mensagem(e) {
    console.log("#### Cliente Cadastrado ###");
    console.log(nome);
    console.log(cpf);
    console.log(dtNasc);

  }

  const cadastrar = () =>{

    const requestOptions = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Nome: nome,
        DataNascimento: dtNasc,
        Cpf: cpf,
      }),
    };
      fetch("http://localhost:5000/api/clientes", requestOptions)
      .then((response) => response.json())
      .then((data) => { console.table(data)})
      mensagem()
    }



  return (
    
<div className="home">
    <div className="pesq" id="pesq">
          <Row id="pesq">
          <Col sm={12}>
              <h4 className='cad'>Cadastrar cliente</h4>
            </Col>
            <Col sm={2}>
            </Col>
            <Col sm={4}>
              <div className="txtNome">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                    placeholder="Nome"
                  />
                </div>
              </Col>
              
              <Col sm={2}>
              <div className="txtNasc">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={dtNasc}
                    onChange={(e) => setDtNasc(dateMask(e.target.value))}
                    placeholder="Data de Nascimento"
                  />
                </div>
              </Col>
              <Col sm={2}>
              <div className="txtCPF">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={cpf}
                    onChange={(e) => setCPF(cpfMask(e.target.value))}
                    placeholder="CPF"
                  />
                </div>
              </Col>
              <Col sm={2}>
            </Col>
            <Col sm={5}>
            </Col>
                <Col sm={2}>
              <Button onClick={() => cadastrar()} size="xl" variant="success" className="btnpesquisar">
                Cadastrar
              </Button>
                </Col>
              </Row>

    </div>
</div>
  );
};

export default Cadastro