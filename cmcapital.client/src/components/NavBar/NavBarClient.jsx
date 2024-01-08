import React from 'react';

function ReactComponent() {
  return (
      <div>
          <nav className="navbar navbar-expand-lg" style={{ backgroundColor:'#4ad295' }}>
              <div className="container-fluid">
                  <div className="collapse navbar-collapse" id="navbarNavDropdown">
                      <ul className="navbar-nav">
                          <li className="nav-item">
                              <a className="nav-link active text" aria-current="page" href="#">CM Capital</a>
                          </li>
                          <li className="nav-item mt-2">
                              <a className="nav-link" href="#">Comprar Produto</a>
                          </li>
                          <li className="nav-item mt-2">
                              <a className="nav-link" href="#">Produtos Mais Vendidos</a>
                          </li>
                          <li className="nav-item mt-2">
                              <a className="nav-link" href="#">Produtos Menos Vendidos</a>
                          </li>
                      </ul>
                  </div>
              </div>
          </nav>
        </div>
  );
}

export default ReactComponent;