pipeline{
    agent any
    stages{
        stage("build"){

            when{
                expression{
                    BRANCH_NAME="development"
                }
            }
            steps{
                echo "========executing A========"
                
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