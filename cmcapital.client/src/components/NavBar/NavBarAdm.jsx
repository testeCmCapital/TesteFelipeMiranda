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
                          {/*<li className="nav-item">*/}
                          {/*    <a className="nav-link" href="#">Features</a>*/}
                          {/*</li>*/}
                          {/*<li className="nav-item">*/}
                          {/*    <a className="nav-link" href="#">Pricing</a>*/}
                          {/*</li>*/}
                          {/*<li className="nav-item dropdown">*/}
                          {/*    <a className="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">*/}
                          {/*        Dropdown link*/}
                          {/*    </a>*/}
                          {/*    <ul className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">*/}
                          {/*        <li><a className="dropdown-item" href="#">Action</a></li>*/}
                          {/*        <li><a className="dropdown-item" href="#">Another action</a></li>*/}
                          {/*        <li><a className="dropdown-item" href="#">Something else here</a></li>*/}
                          {/*    </ul>*/}
                          {/*</li>*/}
                      </ul>
                  </div>
              </div>
          </nav>
        </div>
  );
}

export default ReactComponent;