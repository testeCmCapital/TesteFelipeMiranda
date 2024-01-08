import React, { useState } from 'react';
import NavBar from '../../components/NavBar/NavBarClient';
import './HomeStyle.css';


function Home() {

    return (
        <div>
            <NavBar>
            </NavBar>
            <div className="m-5">
                <div className="col-12">
                    <div className="col-12 text-center">
                        <h3 className="text">Buy product</h3>
                    </div>
                    <div className="col-12 text-end mt-3">
                        <span className="text" style={{fontSize:'14px'}}>Balance: </span>
                    </div>
                    <div className="col-12 mt-5 row">
                        <div className="col-4">
                            <label>Category</label>
                            <select className="form-select" aria-label="Default select example">
                                <option selected>Select category</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </select>
                        </div>
                        <div className="col-4">
                            <label>Product</label>
                            <select className="form-select" aria-label="Default select example">
                                <option selected>Select product</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </select>
                        </div>
                        <div className="col-4">
                            <label>Amount</label>
                            <input type="text" className="form-control" placeholder="Amount"/>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div className="col-12 text-center">
                        <span className="text">Purchase Value: <b>R$3000</b></span>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Home;