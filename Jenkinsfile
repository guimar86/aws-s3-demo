pipeline{
    agent any

    environment{

        DOCKER_REGISTRY_CREDENTIALS=credentials('docker-registry-guillenmartins')
        
    }
    tools{

        maven 'Docker'
    }
    parameters{

        boolean(name:"executeTests", defaultValue:true,description:"Execute tests in stage or not")
        choice(name:"VERSION",defaultValue:['1.0','1.1'],description:"Version of app to run")
    }
    stages{
        stage("build"){

            when{

                expression{

                }
            }
            steps{
                echo "========executing A========"
            }  
        }

        stage("tests"){

        when {

            expression{
                params.executeTests==true
            }
        }

        post{

            failure{
                "tests were not executed. Choice of test execution was ${params.VERSION}"
            }
            success{

            }
        }
        }
        stage("publish"){
            steps{
                echo "========executing A========"
            }
            
        }
    }
    post{
        
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
        }

        always{
            echo "========always========"
            echo "Jenkinsfile end"
        }
    }
}