import React,{useState} from 'react';
import { Form, Col, Row, Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/home.css"


export const dateMask = (value) => {
  return value
    .replace(/\D/g, "")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{2})(\d)/, "$1/$2")
    .replace(/(\d{4})\d+?$/, "$1");
};

 const Clientes = (props) => {
  const [id, setId] = useState("");
  const [dados, setDados] = useState("");
  const [clientes, setClientes] = useState("");

    const pesquisaTodos = () =>{
    const requestOptions = {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    };
      fetch("http://localhost:5000/api/voos", requestOptions)
      .then((response) => response.json())
      .then((data) => {
        setClientes(data)
        console.table(data)
        console.log()
      })

    }

  const pesquisa = async() => {
    const requestOptions = {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    };
    fetch("http://localhost:5000/api/voos/" + id)
    .then((response) => response.json())
    .then((data) => {
      setDados(data)
      console.table(data)
    })
    
    .catch((error) => {
      console.log(error)
    })

    }

  return (
    
<div className="home">
    <div className="pesq" id="pesq">
          <Row id="pesq">
          <Col sm={12}>
              <h4 className='cad'>Consultar clientes</h4>
            </Col>
          <Col sm={4}>
                </Col>
          <Col sm={2}>
              <div className="txtId">
                  <Form.Label className="text-left" style={{ width: "100%" }}>
                  </Form.Label>
                  <Form.Control
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    placeholder="Digite o id para pesquisar"
                  />
                </div>
              </Col>
                <Col sm={2}>
              <Button onClick={pesquisa} size="xl" variant="success" className="btnpesquisar">
                Pesquisar
              </Button>
                </Col>
                <Col sm={4}>
                </Col>
                <Col sm={5}>
                </Col>
                <Col sm={2}>
              <Button onClick={pesquisaTodos} size="xl" variant="success" className="btnpesquisar">
                Listar todos
              </Button>
                </Col>
              </Row>

    </div>
</div>
  );
};

export default Clientes;