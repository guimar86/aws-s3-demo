pipeline{
    agent any

    environment{

        DOCKER_REGISTRY_CREDENTIALS=credentials('docker-registry-guillenmartins')
        
    }
    tools{

        maven 'Maven'
    }
    stages{
        stage("build"){
            steps{
                echo "========executing A========"
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