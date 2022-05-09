import React,{useState} from 'react';
import {NavLink} from 'react-router-dom';
import {FiAlignRight,FiXCircle } from "react-icons/fi";
import Clientes from "./Clientes.jsx"
import Cadastro from "../utils/Cadastro.jsx"
import { Routes, Route } from "react-router-dom";
import Aplicacao from "./Aplicacao"
import Resgate from './Resgate.jsx';
import Investimentos from './Investimentos.jsx';



const Navbarmenu = () => {

    const [isMenu, setisMenu] = useState(false);
    const [isResponsiveclose, setResponsiveclose] = useState(false);
    const toggleClass = () => {
      setisMenu(isMenu === false ? true : false);
      setResponsiveclose(isResponsiveclose === false ? true : false);
  };

    let boxClass = ["main-menu menu-right menuq1"];
    if(isMenu) {
        boxClass.push('menuq2');
    }else{
        boxClass.push('');
    }

  

    return (
        <>
    <header className="header__middle">
        <div className="container">
            <div className="row">

                

                <div className="header__middle__menus">
                    {/* Add Logo  */}
                

                    
                    <nav className="main-nav " >

                    {/* Responsive Menu Button */}
                    {isResponsiveclose === true ? <> 
                        <span className="menubar__button" style={{ display: 'none' }} onClick={toggleClass} > <FiXCircle />   </span>
                    </> : <> 
                        <span className="menubar__button" style={{ display: 'none' }} onClick={toggleClass} > <FiAlignRight />   </span>
                    </>}


                    <ul className={boxClass.join(' ')}>
                    
                    <li className="menu-item " ><NavLink onClick={toggleClass} to={`/`}> Cadastrar Cliente </NavLink> </li>
                    <li className="menu-item " ><NavLink onClick={toggleClass} to={`/clientes`}> Clientes </NavLink> </li>
                    <li className="menu-item " ><NavLink onClick={toggleClass} to={`/aplicacao`}> Aplicação</NavLink> </li>
                    <li className="menu-item " ><NavLink onClick={toggleClass} to={`/resgate`}> Resgate</NavLink> </li>
                    <li className="menu-item " ><NavLink onClick={toggleClass} to={`/investimentos`}> Investimento </NavLink> </li>

                    </ul>

                    </nav>     
                </div>   



        
        
            </div>
	    </div>
    </header>
        
    


        <Routes>
        <Route path="/" element={<Cadastro />} />
        <Route path="/clientes" element={<Clientes />} />
        <Route path="/aplicacao" element={<Aplicacao />} />
        <Route path="/resgate" element={<Resgate />} />
        <Route path="/investimentos" element={<Investimentos />} />

      </Routes>
    
      </>   
       );
    
}

export default Navbarmenu;