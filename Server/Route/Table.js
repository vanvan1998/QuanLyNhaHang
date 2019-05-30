var express = require('express');
var router = express.Router();

router.get('/api/test', function(req, res){
    console.log("test ok");
});
  
module.exports = router;
