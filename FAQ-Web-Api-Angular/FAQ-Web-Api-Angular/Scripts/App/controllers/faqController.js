var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url = '/api/Faq/'
    $scope.loading = true;

    function getAllFaqs() {
        $http.get(url).
            success(function (data) {
                $scope.faqs = data;
                $scope.visTabell = true;
                $scope.visLevering = true;
                $scope.visSupport = true;
                $scope.visBruker = true;
                $scope.visProdukt = true;
                $scope.visAsk = false;
                $scope.visTop = false;
                $scope.visFaqs = true;
                $scope.visQuestions = false;
                $scope.loading = false;
                $('#catTitle').html("Alle FAQ's");
            }).
        error(function (data, status) {
            console.log(status + data);
        });
    };
    getAllFaqs();


    $scope.getAllFaqs = function () {
        getAllFaqs();
    };


    $scope.category = function (data) {

        $scope.visAsk = false;
        $scope.visSupport = false;
        $scope.visBruker = false;
        $scope.visProdukt = false;
        $scope.visTop = false;
        $scope.visLevering = false;
        $scope.visTabell = true;
        console.log(data);

        $('#catTitle').html(data);
        if (data == 'Levering') {
            $scope.visLevering = true;
        }
        if (data == 'Bruker') {
            $scope.visBruker = true;
        }

        if (data == 'Support') {
            $scope.visSupport = true;
        }
        if (data == 'Produkt') {
            $scope.visProdukt = true;
        }

    };

    
       
    $scope.voteUp = function (id) {

        $http.put(url+ id).
        success(function (data) {
            console.log("Voted up:"+id)
        });
    };


    $scope.greaterThan = function (prop, val) {
        $scope.visTop = true;
        $scope.visTabell = false;
        return function (item) {
            if (item[prop] > val) return true;
        }
    };



    $scope.askQuestion = function () {
        
        $scope.visTabell = false;
        $scope.visFaqs = false;
        $scope.visQuestions = false;
        $scope.visAsk = true;
    };



    $scope.listQuestions = function listQuestionsKall() {
        var url = '/api/Question/'
        $http.get(url).
            success(function (data) {
                $scope.questions = data;
                $scope.visQuestions = true;
                $scope.visFaqs = false;
                $scope.visTabell = false;
                $scope.visAsk = false;
            }).
        error(function (data, status) {
            console.log(status + data);
        });
    };




    $scope.saveQuestion = function () {
        var url = '/api/Question/'
        var question = {
            
            title: $scope.title,
            question: $scope.question,
            email: $scope.email,
            name: $scope.name
        };

        $http.post(url, question).
          success(function (data) {
              console.log("Question is saved! OK!")
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };


    $scope.deleteQuestion = function (id) {
        var url = '/api/Question/'
        $http.delete(url + id).
        success(function (data) {
            var url = '/api/Question/'
            $http.get(url).
                success(function (data) {
                    $scope.questions = data;
                    $scope.visQuestions = true;
                    $scope.visFaqs = false;
                    $scope.visTabell = false;
                    $scope.visAsk = false;

                }).
            error(function (data, status) {
                console.log(status + data);
            });

        }).error(function (data, status) {
            console.log(status + data);
        });
    };

  

    $(document).ready(function () {
        $('[data-toggle="popover"]').popover();
    });



}); //end app