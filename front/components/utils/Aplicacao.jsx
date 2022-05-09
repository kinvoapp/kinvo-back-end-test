import React,{useState, useEffect} from 'react';
import { Form, Col, Row, Button, Container } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/home.css"


export const dateMask = (value) => {
  return value
    .replace(/\D/g, "")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{4})\d+?$/, "$1");
};

 const Aplicacao = (props) => {
  const [id, setId] = useState("");
  const [valor, setValor] = useState("");
  const [dtApli, setDtApli] = useState("");

  function mensagem(e) {
    console.log("#### Aplicação cadastrada ###");
    console.log(id);
    console.log(valor);
    console.log(dtApli);
  
  }

  const cadastrar = () =>{

    const requestOptions = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        clienteNome: id,
        clienteDtNasc: valor,
        clienteCpf: dtApli,
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
              <h4 className='cad'>Cadastrar aplicação</h4>
            </Col>
          <Col sm={3}>
                </Col>
          <Col sm={2}>
              <div className="txtId">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Id do produto financeiro"
                  />
                </div>
              </Col>
              <Col sm={2}>
              <div className="txtAplicacao">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={dtApli}
                    onChange={(e) => setDtApli(dateMask(e.target.value))}
                    placeholder="Data da aplicação"
                  />
                </div>
              </Col>
              <Col sm={2}>
              <div className="txtvalor">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={valor}
                    onChange={(e) => setValor(e.target.value)}
                    placeholder="Valor da aplicação"
                  />
                </div>
              </Col>
              <Col sm={3}>
                </Col>
                <Col sm={5}>
                </Col>
                <Col sm={2}>
              <Button onClick={cadastrar} size="xl" variant="success" className="btnpesquisar">
                Cadastrar
              </Button>
                </Col>
              </Row>

    </div>
</div>
  );
};

export default Aplicacao;