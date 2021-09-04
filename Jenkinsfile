pipeline{
    agent any

    environment{

        "DOCKER_REG_USER"="guillenmartins@gmail.com"
        "DOCKER_REG_PASS"="Password123"
        "DEPLOY_USER"='Renato Martins'
    }
    stages{
        stage("build"){
            steps{
                echo "========executing A========"
                echo "Being build by ${DEPLOY_USER} "
            }

            when{

                expression{

                    BRANCH_NAME="master"
                }

            }

            steps{
                echo "Sent from Master branch"
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